using System;

namespace Frontier.CodingChallenge.Models
{
    public class Account
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public  decimal AmountDue { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public int AccountStatusId { get; set; }
        public string Email { get; set; }
    }
}
