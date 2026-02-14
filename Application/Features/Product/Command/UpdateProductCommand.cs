using Application.Interfaces;
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
        public required string Description { get; set; }
        public decimal Rate { get; set; }

        internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {

              var product = _context.products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
               if(product is not null)
                {
                    var productUpdate = new Domain.Entities.Product()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Rate = request.Rate
                    };
                    await _context.SaveChangesAsync();
                    return product.Id;
                }
                return default;
            }
        }
    }
}
