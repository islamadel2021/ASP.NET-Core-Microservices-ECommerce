namespace Matgr.PaymentsAPI.Services
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
