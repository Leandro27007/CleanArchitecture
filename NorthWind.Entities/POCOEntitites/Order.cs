using NorthWind.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.POCOEntitites
{
    public class Order
    {
        public int Id { get; set; }

        public string CustomerID { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipCountry { get; set; }

        public string ShipPostalCode { get; set; }

        public DiscountType DiscountType { get; set; }

        public double Discount {  get; set; }

        public ShippingType ShippingType { get; set; }
    }
}
