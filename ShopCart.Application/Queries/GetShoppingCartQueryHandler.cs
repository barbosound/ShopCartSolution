using MediatR;
using ShopCart.Domain.Enities;
using ShopCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Application.Queries
{
    public class GetShoppingCartQueryHandler : IRequestHandler<GetShoppingCartQuery, ShoppingCartResponse>
    {
        private readonly IShoppingCartRepository _repository;

        public GetShoppingCartQueryHandler(IShoppingCartRepository repository)
        {
            _repository = repository;
        }
        public Task<ShoppingCartResponse> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ShoppingCartResponse(_repository.GetByUserId(request.userId)!));
        }
    }
}
