using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doe.Ls.RAndD.CodeFirst.Bll
{
    public interface IDbContextConfigurationType
    {
         List<object> EntityTypeConfigurationList { get; set; }
    }
}
