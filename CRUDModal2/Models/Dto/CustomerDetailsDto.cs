using System.ComponentModel;

namespace CRUDModal2.Models.Dto
{
    public class CustomerDetailsDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerNumber { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
