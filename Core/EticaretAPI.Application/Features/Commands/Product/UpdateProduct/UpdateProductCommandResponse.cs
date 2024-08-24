using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretApi.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandResponse
    {
        public UpdateProductCommandResponse()
        {
           Message = "Product Updated";
        }
        string Message { get; set; }    
    }
}
