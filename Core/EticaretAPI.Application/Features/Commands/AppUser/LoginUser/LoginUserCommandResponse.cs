using EticaretApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretApi.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
      

      
    }

    public class LoginUserSuccesComandResponse : LoginUserCommandResponse
    {
        public TokenConfig tokenConfig { get; set; }
    }
    public class LoginUsserErrorCommandResponse : LoginUserCommandResponse
    {
        public string message { get; set; } 
    }

}
