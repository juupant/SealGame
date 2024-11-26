using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealGame.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string UserName { get; set; }
    }
}
