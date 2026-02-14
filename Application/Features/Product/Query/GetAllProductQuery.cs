using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Product.Query
{
    public class GetAllProductQuery : IRequest<IEnumerable<Domain.Entities.Product>>
    {
        internal class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Domain.Entities.Product>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProductQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
               var result = await _context.products.ToListAsync(cancellationToken);

                return result;
            }
        }
    }
}
