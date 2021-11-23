using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public string OrderId { get; set; }
        public int? UId { get; set; }
        public DateTime? Date { get; set; }
        public float? Amount { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }

        public virtual User U { get; set; }
    }
}
