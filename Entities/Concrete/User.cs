using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        public string Picture { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
