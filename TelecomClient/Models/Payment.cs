using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TelecomClient.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Balance { get; set; }
    }
}

