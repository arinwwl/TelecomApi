
    using System;
    using System.ComponentModel.DataAnnotations;

    namespace TelecomApi.Models
    {
        public class Payment
        {
            [Key]
            public int Id { get; set; }

            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime PaymentDate { get; set; }
            public decimal MonthlyFee { get; set; }
            public decimal AmountPaid { get; set; }

           
            public decimal Balance => AmountPaid - MonthlyFee;
        }
    }


