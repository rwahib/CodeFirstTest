using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doe.Ls.RAndD.CodeFirst.Bll;

namespace Doe.Ls.RAndD.CodeFirst.Runer
{


    public class DbaseFirstWithDiffrentSchemaTest : TestBase
    {
        protected override void RunCore()
        {
            var ctx = new AdventureWorksEntities();

            foreach (var buildVersion in ctx.AWBuildVersions.Take(10))
            {
                Console.WriteLine(buildVersion.Database_Version);
            }

            foreach (var entity in ctx.BusinessEntities.Take(10))
            {
                Console.WriteLine(entity.Person.LastName);
            }
            foreach (var productDescription in ctx.ProductDescriptions.Take(10))
            {
                Console.WriteLine(productDescription.Description);
            }
        }
    }
}

