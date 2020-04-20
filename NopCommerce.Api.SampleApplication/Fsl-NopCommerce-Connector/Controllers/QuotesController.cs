using Fsl.NopCommerce.Api.Connector.Extensions;
using Fsl.NopCommerce.Api.Connector.Services.Acumatica;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly HubSpotRepository _hubSpot;
        private readonly AcumaticaRepository _acumatica;

        public QuotesController(HubSpotRepository hubSpotRepository, AcumaticaRepository acumaticaRepository)
        {
            _hubSpot = hubSpotRepository ?? throw new ArgumentNullException(nameof(hubSpotRepository));
            _acumatica = acumaticaRepository ?? throw new ArgumentNullException(nameof(acumaticaRepository));
        }

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _hubSpot.Quotes.GetAll();

                return Ok(result);
            }
            catch (HttpRequestException exHttp)
            {
                return StatusCode(402, exHttp.Message);
            }

            //var request = new HubSpotServiceRequest
            //{
            //    Path = "crm/v3/objects/quotes",
            //}
            //.IncludeProperties(
            //    HubSpotProperties.Common.CreatedDate,
            //    HubSpotProperties.Common.LastModifiedDate,
            //    HubSpotProperties.Quote.ExpirationDate,
            //    HubSpotProperties.Quote.PublicUrlKey,
            //    HubSpotProperties.Quote.ApprovalStatus,
            //    HubSpotProperties.Quote.Amount,
            //    HubSpotProperties.Quote.ApproverId,
            //    HubSpotProperties.Quote.Title,
            //    HubSpotProperties.Common.AssociatedDealCount
            //)
            //.WithAssociations(
            //    "deals",
            //    "line_items",
            //    "contacts",
            //    "companies"
            //);

            //var (statusCode, data) = await _service.Get<HubSpotObjectListDTO>(request);

            //if ((int)statusCode < 299 && (int)statusCode > 199)
            //{
            //    return Ok(data);
            //}

            //return StatusCode((int)Status);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var result = await _hubSpot.Quotes.GetById(id);

                if ((result.AssociatedLineItemIds?.Count()).GetValueOrDefault() > 0)
                {
                    result.LineItems = await _hubSpot.LineItems.GetBatch(result.AssociatedLineItemIds.ToArray());
                }

                if ((result.AssociatedCompanyIds?.Count()).GetValueOrDefault() > 0)
                {
                    result.Companies = await _hubSpot.Companies.GetBatch(result.AssociatedCompanyIds.ToArray());
                }

                var newQuote = await SyncQuoteToSalesOrder(result);

                return Ok(newQuote);
            }
            catch (HttpRequestException exHttp)
            {
                return StatusCode(402, exHttp.Message);
            }

            //var request = new HubSpotServiceRequest
            //{
            //    Path = $"crm/v3/objects/quotes/{id}",
            //}
            //.IncludeProperties(
            //    HubSpotProperties.Common.CreatedDate,
            //    HubSpotProperties.Common.LastModifiedDate,
            //    HubSpotProperties.Quote.ExpirationDate,
            //    HubSpotProperties.Quote.PublicUrlKey,
            //    HubSpotProperties.Quote.ApprovalStatus,
            //    HubSpotProperties.Quote.Amount,
            //    HubSpotProperties.Quote.ApproverId,
            //    HubSpotProperties.Quote.Title,
            //    HubSpotProperties.Common.AssociatedDealCount
            //)
            //.WithAssociations(
            //    "deals",
            //    "line_items",
            //    "contacts",
            //    "companies"
            //);

            //var (statusCode, data) = await _service.Get<HubSpotObjectDTO>(request);

            //if ((int)statusCode < 299 && (int)statusCode > 199)
            //{
            //    return Ok(data);
            //}

            //return StatusCode((int)Status);
        }

        private async Task<SalesOrder> SyncQuoteToSalesOrder(HubSpotQuote hubSpotQuote)
        {
            // Get the company associated with the quote.
            var company = hubSpotQuote.Companies.FirstOrDefault();

            if (company == null)
            {
                throw new ApiSynchronizationException(
                    $"The HubSpot quote {hubSpotQuote.Id} must have an associated company and none were found.");
            }

            // Get the associated contacts for the company
            if ((hubSpotQuote.AssociatedContactIds?.Count()).GetValueOrDefault() > 0)
            {
                hubSpotQuote.Contacts = await _hubSpot.Contacts.GetBatch(hubSpotQuote.AssociatedContactIds.ToArray());
            }

            // Save the emails of the contacts for later.
            var companyMainContact = hubSpotQuote.Contacts.FirstOrDefault();

            if (companyMainContact == null)
            {
                throw new InvalidOperationException(
                    $"The company associated with HubSpot quote {hubSpotQuote.Id} must have an associated contact and none were found.");
            }

            // Find any Acumatica customers with the same name as the company.
            var similarAcumaticaCustomers = await _acumatica.Customers.GetListAsync(
                filter: $"substringof('{company.Name}', CustomerName)",
                expand: "MainContact");

            Customer acumaticaCustomer = null;

            // Loop through each Acumatica customer and look for a match with the HubSpot company.
            foreach (var customer in similarAcumaticaCustomers)
            {
                // Does this customer's main contact email match any of the emails from the HubSpot company?
                if (string.Equals(companyMainContact.Email, customer.MainContact?.Email.Value, StringComparison.OrdinalIgnoreCase))
                {
                    // This customer has a main contact with the same email as at least one of the contacts
                    // associated with the HubSpot company. We will assume this customer is the same as the company.
                    acumaticaCustomer = customer;
                    break;
                }
            }

            if (acumaticaCustomer == null)
            {
                var customerToAdd = new Customer
                {
                    CustomerName = new StringValue(company.Name),
                    MainContact = new Contact
                    {
                        CompanyName = new StringValue(company.Name),
                        Active = new BooleanValue(true),
                        Email = new StringValue(companyMainContact.Email),
                        Source = new StringValue("HubSpot Sync"),
                        FirstName = new StringValue(companyMainContact.FirstName),
                        LastName = new StringValue(companyMainContact.LastName),
                        Phone1 = new StringValue(companyMainContact.PhoneNumber),
                        Phone2 = new StringValue(company.Phone),
                        Attention = new StringValue(companyMainContact.GetAttention())
                    },
                };

                // Add a new customer based on information from the HubSpot company.
                acumaticaCustomer = await _acumatica.Customers.PutEntityAsync(
                    customerToAdd,
                    method: EntityAPI<Customer>.PutMethod.Insert);
            }

            if (acumaticaCustomer == null)
            {
                throw new ApiSynchronizationException("The customer associated with this HubSpot quote could not be created in Acumatica");
            }

            //SalesOrderDetail CreateSalesOrderDetailFromLineItem(HubSpotLineItem lineItem)
            //{
            //    var detail = new SalesOrderDetail
            //    {
            //        LineDescription = new StringValue(lineItem.Name),
            //        InventoryID = new StringValue(lineItem.SKU),
            //        DiscountCode = new StringValue(hubSpotQuote.DiscountDisplayStyle.ToString()),
            //    };

            //    detail.DiscountAmount = new DecimalValue(lineItem.Discount);
            //    detail.DiscountPercent = new DecimalValue((decimal)lineItem.DiscountPercentage);
            //    detail.UnitCost = new DecimalValue(lineItem.UnitCost);
            //    detail.UnitPrice = new DecimalValue(lineItem.UnitPrice);
            //    detail.DiscountedUnitPrice = new DecimalValue(lineItem.UnitPrice.GetValueOrDefault() - lineItem.Discount.GetValueOrDefault());
            //    detail.ExtendedPrice = new DecimalValue(lineItem.Amount);
            //    detail.OrderQty = new DecimalValue(lineItem.Quantity);
            //    detail.LineNbr = new IntValue(lineItem.PositionOnQuote);

            //    return detail;
            //}

        var salesOrderToAdd = new SalesOrder
            {
                CustomerID = acumaticaCustomer.CustomerID,
                BillToAddress = new Address
                {
                    AddressLine1 = new StringValue(company.BillingAddress1),
                    AddressLine2 = new StringValue(company.BillingAddress2),
                    City = new StringValue(company.BillingCity),
                    State = new StringValue(company.BillingCountry),
                    PostalCode = new StringValue(company.BillingZip),
                    Country = new StringValue(company.BillingCountry),
                },
                ShipToAddress = new Address
                {
                    AddressLine1 = new StringValue(company.Address1),
                    AddressLine2 = new StringValue(company.Address2),
                    City = new StringValue(company.City),
                    State = new StringValue(company.State),
                    PostalCode = new StringValue(company.Zip),
                    Country = new StringValue(company.Country),
                },
                Date = new DateTimeValue(hubSpotQuote.CreatedDate),
                OrderType = new StringValue("QT"),
                Description = new StringValue(hubSpotQuote.Name),
                Details = hubSpotQuote.LineItems.Select(item =>
                    new SalesOrderDetail
                    {
                        DiscountAmount = new DecimalValue(item.Discount),
                        DiscountPercent = new DecimalValue((decimal?)item.DiscountPercentage),
                        DiscountCode = new StringValue(hubSpotQuote.DiscountDisplayStyle?.ToString()),
                        UnitCost = new DecimalValue(item.UnitCost),
                        UnitPrice = new DecimalValue(item.UnitPrice),
                        DiscountedUnitPrice = new DecimalValue(item.UnitPrice.GetValueOrDefault() - item.Discount.GetValueOrDefault()),
                        ExtendedPrice = new DecimalValue(item.Amount),
                        OrderQty = new DecimalValue(item.Quantity),
                        LineDescription = new StringValue(item.Name),
                        LineNbr = new IntValue(item.PositionOnQuote),
                        InventoryID = new StringValue(item.SKU),
                    }).ToList(),
                OrderTotal = new DecimalValue(hubSpotQuote.Amount),
            };

            var acumaticaQuote = await _acumatica.SalesOrders.PutEntityAsync(
                salesOrderToAdd,
                method: EntityAPI<SalesOrder>.PutMethod.Insert);

            return acumaticaQuote;
        }
    }
}