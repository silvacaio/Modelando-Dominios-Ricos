using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firtsName, string lastName)
        {
            FirtsName = firtsName;
            LastName = lastName;

            if(string.IsNullOrWhiteSpace(FirtsName))
            AddNotification("Name.FirtsName", "Nome inválido");
        }

        public string FirtsName { get; private set; }
        public string LastName { get; private set; }
    }
}