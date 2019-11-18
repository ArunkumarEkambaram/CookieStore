using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.ViewModel
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required,StringLength(100)]
        public string City { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage ="Please enter valid mobile number.")]
        public string MobileNo { get; set; }
    }
}
