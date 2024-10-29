using MediatR;

namespace Application.Notifications;

public class ProductAddedNotification : INotification
{
    public int ProductId { get; set; }
}