﻿using System;

namespace CustomerPortal.Data.Models
{
    public partial class TblCustomer
    {
        public int Id { get; set; }
        public int CustomerTypeId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
