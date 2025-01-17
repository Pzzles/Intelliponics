using System.ComponentModel.DataAnnotations;

namespace Intelliponics.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? PicturePath { get; set; }
        public bool Status { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime Created { get; set; }
        public string Notes { get; set; }

        // Navigation Property
        public ICollection<Order> Orders { get; set; }
    }

}