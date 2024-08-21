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
            //await _productWriteRepository.AddRangeAsync(new()
            //    {
            //        new (){ Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock=10,CreatedAt=DateTime.Now },
            //        new (){ Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock=20,CreatedAt=DateTime.Now },
            //        new (){ Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock=30,CreatedAt=DateTime.Now },
            //        new (){ Id = Guid.NewGuid(), Name = "Product 4", Price = 400, Stock=40,CreatedAt=DateTime.Now }
            //    });

            //await _productWriteRepository.SaveAsync();

            //Tracking Mekeizması ÖRneği
            //var p = await _productReadRepository.GetByIdAsync("eedca6f6-35e3-4170-8560-932fb8efb219");// tracking mekanizması takip edecek
            //p.Name = "Ahmet";

            //Tracking Mekeizması ÖRneği
            //var pe = await _productReadRepository.GetByIdAsync("eedca6f6-35e3-4170-8560-932fb8efb219",false);// tracking mekanizması takip etmeyecek
            //pe.Name = "asdasdasdasd"; // tracking olmadığı için değişiklik yapamayız
            //await _productWriteRepository.SaveAsync();

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
