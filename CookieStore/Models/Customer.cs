using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobileNo { get; set; }
    }

    public class Orders : Customer
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalQty { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
