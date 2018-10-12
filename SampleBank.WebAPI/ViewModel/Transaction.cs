using SampleBank.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleBank.WebAPI.ViewModel
{
    public class Transaction
    {
        public int CustomerId { get; set; }
        public int BeneficieryId { get; set; }
        public int Amount { get; set; }
    }
}