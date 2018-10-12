using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SampleBank.WebAPI.Models;
using SampleBank.WebAPI.Data;
using SampleBank.WebAPI.ViewModel;

namespace SampleBank.WebAPI.Controllers
{
    public class TransactionController : ApiController
    {
        public void Post(Transaction transaction)
        {
            // TODO: Add validation
            var customer = CustomerList.list.FirstOrDefault(i => i.Id == transaction.CustomerId);
            var beneficiary = CustomerList.list.FirstOrDefault(i => i.Id == transaction.BeneficieryId);

            // deduct money from customer account
            customer.Balance = customer.Balance - transaction.Amount;

            // add money from beneficiary account
            beneficiary.Balance = customer.Balance + transaction.Amount;
        }
    }
}