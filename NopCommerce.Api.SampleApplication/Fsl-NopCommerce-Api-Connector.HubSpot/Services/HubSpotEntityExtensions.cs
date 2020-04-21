using Fsl.NopCommerce.Api.Connector.DTOs.HubSpot;
using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using System.Linq;

namespace Fsl.NopCommerce.Api.Connector.Services
{
    static class HubSpotEntityExtensions
    {
        public static TEntity AddAssociatedIds<TEntity>(this TEntity entity, HubSpotObjectDTO dto, EntityOptions options) where TEntity : HubSpotEntity
        {
            switch (entity)
            {
                case HubSpotQuote quote:
                    {
                        if (!options.ExcludeCompanies && dto.Associations?.Companies?.Results != null)
                        {
                            quote.AssociatedCompanyIds = dto.Associations.Companies.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeLineItems && dto.Associations?.Line_Items?.Results != null)
                        {
                            quote.AssociatedLineItemIds = dto.Associations.Line_Items.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeContacts && dto.Associations?.Contacts?.Results != null)
                        {
                            quote.AssociatedContactIds = dto.Associations.Contacts.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeDeals && dto.Associations?.Deals?.Results != null)
                        {
                            quote.AssociatedDealIds = dto.Associations.Deals.Results.Select(link => link.Id);
                        }

                        break;
                    }

                case HubSpotCompany company:
                    {
                        if (!options.ExcludeQuotes && dto.Associations?.Quotes?.Results != null)
                        {
                            company.AssociatedQuoteIds = dto.Associations.Quotes.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeLineItems && dto.Associations?.Line_Items?.Results != null)
                        {
                            company.AssociatedLineItemIds = dto.Associations.Line_Items.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeContacts && dto.Associations?.Contacts?.Results != null)
                        {
                            company.AssociatedContactIds = dto.Associations.Contacts.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeDeals && dto.Associations?.Deals?.Results != null)
                        {
                            company.AssociatedDealIds = dto.Associations.Deals.Results.Select(link => link.Id);
                        }

                        break;
                    }

                case HubSpotLineItem lineItem:
                    {
                        if (!options.ExcludeQuotes && dto.Associations?.Quotes?.Results != null)
                        {
                            lineItem.AssociatedQuoteIds = dto.Associations.Quotes.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeCompanies && dto.Associations?.Companies?.Results != null)
                        {
                            lineItem.AssociatedCompanyIds = dto.Associations.Companies.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeContacts && dto.Associations?.Contacts?.Results != null)
                        {
                            lineItem.AssociatedContactIds = dto.Associations.Contacts.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeDeals && dto.Associations?.Deals?.Results != null)
                        {
                            lineItem.AssociatedDealIds = dto.Associations.Deals.Results.Select(link => link.Id);
                        }

                        break;
                    }

                case HubSpotContact contact:
                    {
                        if (!options.ExcludeQuotes && dto.Associations?.Quotes?.Results != null)
                        {
                            contact.AssociatedQuoteIds = dto.Associations.Quotes.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeCompanies && dto.Associations?.Companies?.Results != null)
                        {
                            contact.AssociatedCompanyIds = dto.Associations.Companies.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeLineItems && dto.Associations?.Line_Items?.Results != null)
                        {
                            contact.AssociatedLineItemIds = dto.Associations.Line_Items.Results.Select(link => link.Id);
                        }

                        if (!options.ExcludeDeals && dto.Associations?.Deals?.Results != null)
                        {
                            contact.AssociatedDealIds = dto.Associations.Deals.Results.Select(link => link.Id);
                        }

                        break;
                    }
            }

            return entity;
        }
    }
}
