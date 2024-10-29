using Application.Commands;
using Application.Notifications;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Application.CommandHandlers;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
{
    private readonly IProductRepository _productRepository;
    private readonly IMediator _mediator;

    public AddProductCommandHandler(IProductRepository productRepository, 
        IMediator mediator)
    {
        _productRepository = productRepository;
        _mediator = mediator;
    }

    public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price
        };

        await _productRepository.AddProductAsync(product);
        
        // Notification gönderimi
        await _mediator.Publish(new ProductAddedNotification { ProductId = product.Id }, cancellationToken);
        return product.Id;
    }
}