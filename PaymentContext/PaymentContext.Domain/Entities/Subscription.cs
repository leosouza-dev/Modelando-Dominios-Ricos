using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool Active { get; set; }
        
        // lista de pagamento - tipo genérico/abstrato
        public List<Payment> Payments { get; set; }
    }
}