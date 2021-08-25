using System.Collections.Generic;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class RoleListDto
    {
        public IList<Role> Roles { get; set; }
    }
}
