using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Fsl.NopCommerce.Api.Connector.Services.Acumatica
{
    /// <summary>
    /// Credentials
    /// </summary>
    [DataContract]
    public partial class Credentials : IEquatable<Credentials>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Credentials() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="password">password (required).</param>
        /// <param name="company">company.</param>
        /// <param name="tenant">tenant.</param>
        /// <param name="branch">branch.</param>
        /// <param name="locale">locale.</param>
        public Credentials(string name = default, string password = default, string company = default, string tenant = default, string branch = default, string locale = default)
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for Credentials and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "password" is required (not null)
            if (password == null)
            {
                throw new InvalidDataException("password is a required property for Credentials and cannot be null");
            }
            else
            {
                Password = password;
            }
            Company = company;
            Tenant = tenant;
            Branch = branch;
            Locale = locale;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets Company
        /// </summary>
        [DataMember(Name = "company", EmitDefaultValue = false)]
        public string Company { get; set; }

        /// <summary>
        /// Gets or Sets Tenant
        /// </summary>
        [DataMember(Name = "tenant", EmitDefaultValue = false)]
        public string Tenant { get; set; }

        /// <summary>
        /// Gets or Sets Branch
        /// </summary>
        [DataMember(Name = "branch", EmitDefaultValue = false)]
        public string Branch { get; set; }

        /// <summary>
        /// Gets or Sets Locale
        /// </summary>
        [DataMember(Name = "locale", EmitDefaultValue = false)]
        public string Locale { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Credentials {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Company: ").Append(Company).Append("\n");
            sb.Append("  Tenant: ").Append(Tenant).Append("\n");
            sb.Append("  Branch: ").Append(Branch).Append("\n");
            sb.Append("  Locale: ").Append(Locale).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as Credentials);
        }

        /// <summary>
        /// Returns true if Credentials instances are equal
        /// </summary>
        /// <param name="input">Instance of Credentials to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Credentials input)
        {
            if (input == null)
                return false;

            return
                (
                    Name == input.Name ||
                    (Name != null &&
                    Name.Equals(input.Name))
                ) &&
                (
                    Password == input.Password ||
                    (Password != null &&
                    Password.Equals(input.Password))
                ) &&
                (
                    Company == input.Company ||
                    (Company != null &&
                    Company.Equals(input.Company))
                ) &&
                (
                    Tenant == input.Tenant ||
                    (Tenant != null &&
                    Tenant.Equals(input.Tenant))
                ) &&
                (
                    Branch == input.Branch ||
                    (Branch != null &&
                    Branch.Equals(input.Branch))
                ) &&
                (
                    Locale == input.Locale ||
                    (Locale != null &&
                    Locale.Equals(input.Locale))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode() => HashCode.Combine(Name, Password, Company, Tenant, Branch, Locale);

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}