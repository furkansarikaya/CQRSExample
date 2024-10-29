using MediatR;

namespace Application.Commands;

public class AddProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}