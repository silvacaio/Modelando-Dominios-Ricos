using Flunt.Validations;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firtsName, string lastName)
        {
            FirtsName = firtsName;
            LastName = lastName;

            // if(string.IsNullOrWhiteSpace(FirtsName))
            //AddNotification("Name.FirtsName", "Nome inválido");

            AddNotifications(new Contract()
                            .Requires()
                            .HasMinLen(FirtsName, 3, "Name.FirtsName", "O nome deve ter ao menos 3 caracteres")
                            .HasMinLen(LastName, 3, "Name.LastName", "O sobrenome deve ter ao menos 3 caracteres")
                            .HasMaxLen(FirtsName, 40, "Name.FirtsName", "O nome deve ter até 40 caracteres"));
        }

        public string FirtsName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirtsName, LastName);
        }
    }
}