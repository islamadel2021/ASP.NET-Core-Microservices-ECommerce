using Matgr.MessageBus;

namespace Matgr.PaymentsAPI.RabbitMQSender
{
    public interface IRabbitMQPaymentResultMessageSender
    {
        void SendMessage(BaseMessage message);
    }
}
