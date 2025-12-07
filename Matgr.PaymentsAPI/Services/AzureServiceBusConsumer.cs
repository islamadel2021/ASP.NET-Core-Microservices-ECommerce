using Azure.Messaging.ServiceBus;
using Matgr.MessageBus;
using Matgr.PaymentsAPI.Models.Dtos;
using Matgr.PaymentsAPI.Repository;
using Newtonsoft.Json;
using System.Text;

namespace Matgr.PaymentsAPI.Services
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IMessageBus _messageBus;
        private readonly IConfiguration _configuration;
        private readonly string _serviceBusConnectionString;
        private readonly string _paymentRequestSubscription;
        private readonly string _paymentRequestTopic;
        private readonly string _paymentUpdateTopic;
        private ServiceBusProcessor _paymentRequestProcessor;

        public AzureServiceBusConsumer(IPaymentProcessor paymentProcessor,
            IMessageBus messageBus, IConfiguration configuration)
        {
            _paymentProcessor = paymentProcessor;
            _messageBus = messageBus;
            _configuration = configuration;
            _serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            _paymentRequestSubscription = _configuration.GetValue<string>("PaymentRequestSubscription");
            _paymentRequestTopic = _configuration.GetValue<string>("PaymentRequestTopic");
            _paymentUpdateTopic = _configuration.GetValue<string>("PaymentUpdateTopic");

            var client = new ServiceBusClient(_serviceBusConnectionString);
            _paymentRequestProcessor = client.CreateProcessor(_paymentRequestTopic, _paymentRequestSubscription);
        }

        public async Task Start()
        {
            _paymentRequestProcessor.ProcessMessageAsync += OnPaymentRequestMessageReceived;
            _paymentRequestProcessor.ProcessErrorAsync += ErrorHandler;
            await _paymentRequestProcessor.StartProcessingAsync();
        }

        public async Task Stop()
        {
            await _paymentRequestProcessor.StopProcessingAsync();
            await _paymentRequestProcessor.DisposeAsync();
        }

        private Task ErrorHandler(ProcessErrorEventArgs arg)
        {
            Console.WriteLine(arg.Exception.ToString());
            return Task.CompletedTask;
        }

        private async Task OnPaymentRequestMessageReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);
            var paymentRequestMessageDto = JsonConvert.DeserializeObject<PaymentRequestMessageDto>(body);
            var result = _paymentProcessor.ProcessPayment();
            var paymentUpdateMessage = new PaymentUpdateMessageDto()
            {
                OrderId = paymentRequestMessageDto.OrderId,
                Status = result,
                Email = paymentRequestMessageDto.Email
            };

            try
            {
                await _messageBus.PublishMessage(paymentUpdateMessage, _paymentUpdateTopic);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
