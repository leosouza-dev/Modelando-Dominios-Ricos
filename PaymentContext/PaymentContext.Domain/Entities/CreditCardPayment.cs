using System;

namespace PaymentContext.Domain.Entities
{
  public class CreditCardPayment : Payment
  {
    public CreditCardPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address, string email, string cardHoldName, string cardNumber, string lastTransactionNumber) : base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
    {
      CardHoldName = cardHoldName;
      CardNumber = cardNumber;
      LastTransactionNumber = lastTransactionNumber;
    }

    // usar gateway de pagamento
    // processo de "pci" - averiguar informações
    // se vazar dados de cartão de crédito - fu***
    // não armazenar ccv e data de expiração
    public string CardHoldName { get; private set; }

    // ultimos digitos apenas 
    public string CardNumber { get; private set; }
    public string LastTransactionNumber { get; private set; }
  }
}