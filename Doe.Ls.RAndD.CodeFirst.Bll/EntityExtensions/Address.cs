namespace Doe.Ls.RAndD.CodeFirst.Bll.CodeFirstEntities
{
   
    public partial class Address
    {
        public override string ToString()
        {
            return $"{AddressLine1}-{City}";
        }
    }
}
