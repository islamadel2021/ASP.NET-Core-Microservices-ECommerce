using Matgr.MessageBus;

namespace Matgr.ShoppingCartAPI.RabbitMQSender
{
    public interface IRabbitMQCheckoutMessageSender
    {
        void SendMessage(BaseMessage message, string queueName);
    }
}
