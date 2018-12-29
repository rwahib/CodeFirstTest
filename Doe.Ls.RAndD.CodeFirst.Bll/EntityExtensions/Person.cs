namespace Doe.Ls.RAndD.CodeFirst.Bll.CodeFirstEntities
{

    public partial class Person
    {
        public override string ToString()
        {
            return $"{this.FirstName}-{this.LastName}";
        }
    }
}
