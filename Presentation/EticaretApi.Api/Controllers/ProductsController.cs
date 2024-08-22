using EticaretApi.Application.Features.Commands.CreateProduct;
using EticaretApi.Application.Features.Queries.GetAllProduct;
using EticaretApi.Application.Repositories;
using EticaretApi.Domain.Entities;
using MediatR;
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
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;
        readonly IMediator _mediator;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository, IMediator mediator)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    //await _productWriteRepository.AddRangeAsync(new()
        //    //    {
        //    //        new (){ Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock=10,CreatedAt=DateTime.Now },
        //    //        new (){ Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock=20,CreatedAt=DateTime.Now },
        //    //        new (){ Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock=30,CreatedAt=DateTime.Now },
        //    //        new (){ Id = Guid.NewGuid(), Name = "Product 4", Price = 400, Stock=40,CreatedAt=DateTime.Now }
        //    //    });

        //    //await _productWriteRepository.SaveAsync();

        //    //Tracking Mekeizması ÖRneği
        //    //var p = await _productReadRepository.GetByIdAsync("eedca6f6-35e3-4170-8560-932fb8efb219");// tracking mekanizması takip edecek
        //    //p.Name = "Ahmet";

        //    //Tracking Mekeizması ÖRneği
        //    //var pe = await _productReadRepository.GetByIdAsync("eedca6f6-35e3-4170-8560-932fb8efb219",false);// tracking mekanizması takip etmeyecek
        //    //pe.Name = "asdasdasdasd"; // tracking olmadığı için değişiklik yapamayız
        //    //await _productWriteRepository.SaveAsync();


        //    //await _productWriteRepository.AddAsync(new()
        //    //{
        //    //    Name = "C Product",
        //    //    Price = 1.500F,
        //    //    Stock = 10,
        //    //    CreatedAt = DateTime.Now // her veride bunu vermek isteyecem ama her seferinde yazmak istemem Interceptor ile yapabilirim bu işi 
        //    //});
        //    //await _productWriteRepository.SaveAsync();  


        //    //await _orderWriteRepository.AddAsync(new()
        //    //{
        //    //    Description = "Order 1",
        //    //    Address = "Istanbul",
        //    //    Customer = new()
        //    //    {
        //    //        Name = "Ahmet",
        //    //    }

        //    //});
        //    //await _orderWriteRepository.AddAsync(new()
        //    //{
        //    //    Description = "Order 2",
        //    //    Address = "Istanbul",
        //    //    Customer = new()
        //    //    {
        //    //        Name = "Mehmet",
        //    //    }

        //    //});
        //    //await _orderWriteRepository.SaveAsync();




        //  //Order order=  await _orderReadRepository.GetByIdAsync("08dcc1fd-47eb-4a15-8d86-667aec961a59");
        //  //order.Description = "Order 1 Updated";
        //  //order.Description = "Order 1 Updated 2";
        //  //await _orderWriteRepository.SaveAsync();

        //  //  return Ok();



        //}

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
              GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
              return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }


    }
}
