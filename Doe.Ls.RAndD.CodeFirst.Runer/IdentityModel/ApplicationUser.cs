using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Doe.Ls.RAndD.CodeFirst.Runer.IdentityModel
{
    
    public class ApplicationUser: IdentityUser
    {
        public int? SchoolCode { get; set; }
        public int? TitleId { get; set; }
        public string Position { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
