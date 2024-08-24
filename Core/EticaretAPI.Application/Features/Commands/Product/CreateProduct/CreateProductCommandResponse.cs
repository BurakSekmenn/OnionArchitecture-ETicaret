using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretApi.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public CreateProductCommandResponse()
        {
            MyProperty = "Başarılı Bir Şekilde Oluşturuldu";
        }
        public string MyProperty { get; set; }
    }
}
