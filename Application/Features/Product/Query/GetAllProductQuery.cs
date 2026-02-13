using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Product.Query
{
    public class GetAllProductQuery : IRequest<IEnumerable<Domain.Entities.Product>>
    {
        internal class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Domain.Entities.Product>>
        {
            public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var productList = new List<Domain.Entities.Product>();

                for (int i = 0; i < 100; i++)
                {
                    var prod = new Domain.Entities.Product()
                    {
                        Name = "Mobile",
                        Description = "New Lunch",
                        Rate = 99.99M + i
                    };
                    productList.Add(prod);
                }
                return productList;
            }
        }
    }
}
