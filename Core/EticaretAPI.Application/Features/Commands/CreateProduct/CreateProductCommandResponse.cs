using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretApi.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public CreateProductCommandResponse()
        {
            this.MyProperty = "Başarılı Bir Şekilde Oluşturuldu";
        }
        public string MyProperty { get; set; }
    }
}
