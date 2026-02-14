using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Product.Command
{
    public class CreateProductCommand : IRequest<int>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Rate { get; set; }

        internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Domain.Entities.Product()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Rate = request.Rate

                };
                await _context.products.AddAsync(product);

                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
