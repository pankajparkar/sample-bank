using System;

namespace SampleBank.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public CustomerType CustomerType { get; set; }
        public GenderEnum Gender { get; set; }
        public int CityId { get; set; }
        public int? PinCode { get; set; }
    }
}
