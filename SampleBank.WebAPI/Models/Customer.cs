using System;
namespace SampleBank.WebAPI.Models
{
    public enum CustomerType {
        Saving,
        Current
    }
    public class Customer
    {
        public Customer() {}
        public Customer(int id, string name, decimal balance, bool isActive, CustomerType customerType, int stateId, int pinCode) {
            Id = id;
            Name = name;
            Balance = balance;
            IsActive = isActive;
            CustomerType = customerType;
            StateId = stateId;
            PinCode = pinCode;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public CustomerType CustomerType { get; set; }
        public int StateId { get; set; }
        public int PinCode { get; set; }
    }
}
