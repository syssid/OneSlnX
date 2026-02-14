using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Product.Command
{
    public class DeleteProductCommand : IRequest<int>
    {
        public  int Id { get; set; }

        internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (product is null)
                    return default!;
                _context.products.Remove(product);

                await _context.SaveChangesAsync();

                return request.Id;
            }
        }
    }
}
