using Application.Notifications;
using MediatR;

namespace Application.NotificationHandlers;

public class ProductAddedNotificationHandler : INotificationHandler<ProductAddedNotification>
{
    public Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        // Örnek: Loglama veya mesaj kuyruğuna gönderim işlemi yapılabilir.
        Console.WriteLine($"Yeni ürün eklendi: {notification.ProductId}");
        return Task.CompletedTask;
    }
}