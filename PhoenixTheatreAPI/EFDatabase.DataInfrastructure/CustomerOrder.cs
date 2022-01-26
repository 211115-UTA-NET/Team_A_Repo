﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoenixTheatre.DataInfrastructure
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItem>();
        }
        [Key]
        public Guid OrderId { get; set; }
        public Guid? CustomerId { get; set; }
        public int? TheatreId { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Theatre? Theatre { get; set; }
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
    }
}