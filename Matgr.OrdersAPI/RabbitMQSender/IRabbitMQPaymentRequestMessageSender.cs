using Matgr.MessageBus;

namespace Matgr.OrdersAPI.RabbitMQSender
{
    public interface IRabbitMQPaymentRequestMessageSender
    {
        void SendMessage(BaseMessage message, string queueName);
    }
}
