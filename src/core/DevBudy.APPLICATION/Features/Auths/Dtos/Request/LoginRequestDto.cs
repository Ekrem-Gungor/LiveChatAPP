using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.APPLICATION.Features.Auths.Dtos.Request
{
    public class LoginRequestDto
    {
        public string UserName { get; set; }
        public int Password { get; set; }
    }
}
