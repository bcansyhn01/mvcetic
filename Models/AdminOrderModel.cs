using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCS.MvcWeb.Entity;

namespace BCS.MvcWeb.Models
{
    public class AdminOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int Count { get; set; }
        public double Total { get; set; }
        public EnumOrderState OrderState { get; set; }
        public DateTime OrderDate { get; set; }
    }
}