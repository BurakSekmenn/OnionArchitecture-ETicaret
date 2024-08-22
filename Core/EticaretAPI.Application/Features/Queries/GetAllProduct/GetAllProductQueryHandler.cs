using EticaretApi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretApi.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }


        // IRequestHandler interface'inden gelen Handle metodu implemente edilir. 
        public Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount =  _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false)
                .Skip((request.Page) * request.Size)
                .Take(request.Size).Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.Stock,
                    p.CreatedAt,
                    p.UpdatedDate
                })
                .ToList();

            return Task.FromResult(new GetAllProductQueryResponse { TotalCount = totalCount, Products = products });
        }
    }
}
