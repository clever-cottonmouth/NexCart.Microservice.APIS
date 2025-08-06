using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexCart.Users.DTO
{
    public record UserDTO(Guid UserId, string? Email, string? PersonName, string Gender);

}
