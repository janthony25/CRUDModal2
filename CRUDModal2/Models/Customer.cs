using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDModal2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public required string CustomerName { get; set; }

        [DisplayName("Email Address")]
        public required string CustomerEmail { get; set; }

        [DisplayName("Contact #")]
        public string CustomerNumber { get; set; }

        [DisplayName("Date Added")]
        public DateTime DateAdded { get; set; } = DateTime.Now;

    }
}
