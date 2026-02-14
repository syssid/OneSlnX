using Application.Interfaces;
using AutoMapper;
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
            private readonly IMapper _mapper;
            public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Domain.Entities.Product>(request);
                await _context.products.AddAsync(product);

                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
