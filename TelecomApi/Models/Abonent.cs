
    using System.ComponentModel.DataAnnotations;

    namespace TelecomApi.Models
    {
        public class Abonent
        {
            [Key]
            public string LastName { get; set; }  

            public string PhoneNumber { get; set; }
            public decimal MonthlyFee { get; set; }
        }
    }


