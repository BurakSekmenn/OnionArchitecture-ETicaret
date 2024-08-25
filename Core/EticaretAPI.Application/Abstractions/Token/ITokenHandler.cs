using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretApi.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
      
        Dtos.TokenConfig CreateAccesToken(int minute);

    }
}
