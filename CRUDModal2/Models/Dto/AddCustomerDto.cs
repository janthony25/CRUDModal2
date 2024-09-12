using System.ComponentModel;

namespace CRUDModal2.Models.Dto
{
    public class AddCustomerDto
    {
        public required string CustomerName { get; set; }
        public required string CustomerEmail { get; set; }
        public string CustomerNumber { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
