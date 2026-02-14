using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Product.Command
{
    public class UpdateProductCommand : IRequest<int>
    {
        public  int Id { get; set; }
        public required string Name { get; set; }
        public required string Remarks { get; set; }
        public decimal Rate { get; set; }

        internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public UpdateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.products
                    .Where(x => x.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);

                if (product is null)
                    return default;

                // Map into the existing tracked entity
                _mapper.Map(request, product);

                await _context.SaveChangesAsync();

                return product.Id;
            }
        }
    }
}
