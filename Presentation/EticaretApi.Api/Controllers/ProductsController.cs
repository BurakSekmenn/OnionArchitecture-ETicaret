using EticaretApi.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EticaretApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
                {
                    new (){ Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock=10,CreatedAt=DateTime.Now },
                    new (){ Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock=20,CreatedAt=DateTime.Now },
                    new (){ Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock=30,CreatedAt=DateTime.Now },
                    new (){ Id = Guid.NewGuid(), Name = "Product 4", Price = 400, Stock=40,CreatedAt=DateTime.Now }
                });

            await _productWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
