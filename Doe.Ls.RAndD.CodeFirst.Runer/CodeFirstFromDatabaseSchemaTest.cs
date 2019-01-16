using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doe.Ls.RAndD.CodeFirst.Bll;
using Doe.Ls.RAndD.CodeFirst.Bll.CodeFirstEntities;
using Newtonsoft.Json;
//using Address = Doe.Ls.RAndD.CodeFirst.Bll.Address;

namespace Doe.Ls.RAndD.CodeFirst.Runer
{


    public class CodeFirstFromDatabaseSchemaTest : TestBase
    {
        /// <summary>
        /// Retrieve data
        /// </summary>
        protected override void RunCore()
        {
            // RtrieveTest();
            //UpdateTest();
            CheckMetadata();

        }

        private void CheckMetadata()
        {
            using (var ctx = new AdventureCtx())
            {
               var x= ctx.Addresses.Include(a=>a.SalesOrderHeaders).Where(a=>a.SalesOrderHeaders.Any()).FirstOrDefault().SalesOrderHeaders;

                if (x.Any())
                {
                    PrintMessage(x.FirstOrDefault().AccountNumber);

                    var y = x.FirstOrDefault().SalesOrderDetails.FirstOrDefault();
                    PrintMessage(y.rowguid.ToString());

                }

            }
        }

        private void RtrieveTest()
        {
            var ctx = new AdventureCtx();

            PrintMessage(Wordfiy("Print SalesOrders"));

            foreach (var salesOrderHeader in ctx.SalesOrderHeaders.Take(10))
            {
                Console.WriteLine($"{salesOrderHeader.Customer.Person}  {salesOrderHeader.CreditCard.CardType}  {salesOrderHeader.CreditCard.CardNumber.Substring(0, 3).PadRight(20, '*')}  {salesOrderHeader.SubTotal.ToString("C0")}");
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
        private void UpdateTest()
        {
            using (var ctx = new AdventureCtx())
            {

                PrintMessage(Wordfiy("Update address"));

                var address = ctx.Addresses.FirstOrDefault();
                var addresJson = JsonConvert.SerializeObject(address, Formatting.None);
                var clonedAddress = JsonConvert.DeserializeObject<Address>(addresJson);
                PrintMessage($"Address before change {address}");
                address.City = "Sydney";
                address.AddressLine1 = "1 Evanse Avenue";

                ctx.SaveChanges();
                var savedAddress = ctx.Addresses.SingleOrDefault(a => a.rowguid == address.rowguid);
                PrintMessage($"Address after change {savedAddress}");

                savedAddress.City = clonedAddress.City;
                savedAddress.AddressLine1 = clonedAddress.AddressLine1;
                ctx.SaveChanges();
                PrintMessage($"Address after restoration  {savedAddress}");

            }


        }
    }
}

