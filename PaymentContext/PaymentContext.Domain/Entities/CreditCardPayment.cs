namespace PaymentContext.Domain.Entities
{
  public class CreditCardPayment : Payment
    {
        // usar gateway de pagamento
        // processo de pci - averiguar informações
        // se vazar dados de cartão de crédito - fu***
        // não armazenar ccv e data de expiração
        public string CardHoldName { get; set; }

        // ultimos digitos apenas 
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
    }
}