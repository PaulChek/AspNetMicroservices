using Ordering.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Ordering.Domain.Model {
    public class Order : ModelBase {
        [Required]
        [MaxLength(44)]
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }

        // BillingAddress
        [MaxLength(44)]
        public string FirstName { get; set; }
        [MaxLength(44)]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
        [MaxLength(100)]
        public string AddressLine { get; set; }
        [MaxLength(25)]
        public string Country { get; set; }
        [MaxLength(25)]
        public string State { get; set; }
        [MaxLength(14)]
        public string ZipCode { get; set; }

        // Payment
        [MaxLength(20)]
        public string CardName { get; set; }
        [MaxLength(20)]
        public string CardNumber { get; set; }
        [MaxLength(10)]
        public string Expiration { get; set; }
        [MaxLength(3)]
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }
    }
}
