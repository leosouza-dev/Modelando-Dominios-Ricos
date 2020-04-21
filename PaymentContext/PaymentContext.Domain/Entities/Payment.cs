using System;

namespace PaymentContext.Domain.Entities
{
  public abstract class Payment
    {
        // numero do pagamento - identificação interna
        public string Number { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string Document { get; set; }

        //Enedreço de cobrança - para criação de nota
        public string Address { get; set; }
        public string Email { get; set; }

    }
}