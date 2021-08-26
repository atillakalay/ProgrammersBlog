
using System.Collections.Generic;

namespace Entities.Dtos
{
    public class UserRoleAssignDto
    {
        public UserRoleAssignDto()
        {
            RoleAssignDtos = new List<RoleAssignDto>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<RoleAssignDto> RoleAssignDtos { get; set; }
    }
}
