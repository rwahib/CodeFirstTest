using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doe.Ls.RAndD.CodeFirst.Bll;
using Doe.Ls.RAndD.CodeFirst.Bll.CodeFirstEntities;

namespace Doe.Ls.RAndD.CodeFirst.Runer
{


    public class CodeFirstFromDatabaseSchemaTest : TestBase
    {
        protected override void RunCore()
        {
            var ctx = new AdventureCtx();

            PrintMessage(Wordfiy("Print SalesOrders"));

            foreach (var salesOrderHeader in ctx.SalesOrderHeaders.Take(10))
            {
                Console.WriteLine($"{salesOrderHeader.Customer.Person}  {salesOrderHeader.CreditCard.CardType}  {salesOrderHeader.CreditCard.CardNumber.Substring(0,3).PadRight(20,'*')}  {salesOrderHeader.SubTotal.ToString("C0")}");
            }
            PrintMessage(Wordfiy("Print Addresses"));

            foreach (var address in ctx.Addresses.Take(10))
            {
                Console.WriteLine($"{address.AddressLine1}-{address.City}");
            }
            PrintMessage(Wordfiy("Print SalesTerritories"));

            foreach (var territory in ctx.SalesTerritories.Take(10))
            {
                Console.WriteLine(territory.Name);
            }
            PrintMessage(Wordfiy("Print ProductDescriptions"));
            foreach (var productDescription in ctx.ProductDescriptions.Take(10))
            {
                Console.WriteLine(productDescription.Description);
            }
        }
    }
}

