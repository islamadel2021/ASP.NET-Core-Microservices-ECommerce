namespace Matgr.OrdersAPI.Services
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
