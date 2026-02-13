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
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                // logic

                return 1;
            }
        }
    }
}
