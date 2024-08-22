using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretApi.Application.Features.Commands
{
    public record CommandResponse<T>(bool Succes, string message);
   
}
