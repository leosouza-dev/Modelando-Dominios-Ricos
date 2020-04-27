using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Address : ValueObject
  {
    public Address(string street, string number, string neighborhood, string city, string state, string zipCode, string country)
    {
      Street = street;
      Number = number;
      Neighborhood = neighborhood;
      City = city;
      State = state;
      ZipCode = zipCode;
      Country = country;

      AddNotifications(new Contract()
       .Requires()
          .HasMinLen(Street, 3, "Address.Street", "Rua deve conter pelo menos 3 caracteres")
          .HasMaxLen(Street, 40, "Address.Street", "Rua deve ter até 40 caracteres")
      );
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }
  }
}
