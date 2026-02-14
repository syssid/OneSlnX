using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Product.Query
{
    public class GetProductByIDQuery : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }
        internal class GetProductByIDQueryHandler : IRequestHandler<GetProductByIDQuery, Domain.Entities.Product>
        {
            private readonly IApplicationDbContext _context;
            public GetProductByIDQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Domain.Entities.Product> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

                return result!;
            }
        }
    }
}