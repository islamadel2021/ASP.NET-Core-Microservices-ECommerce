namespace Matgr.EmailsAPI.Services
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
