using System;
namespace SampleBank.WebAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public CustomerType CustomerType { get; set; }
        public GenderEnum Gender { get; set; }
        public int StateId { get; set; }
        public int PinCode { get; set; }
    }
}
