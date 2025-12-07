using Matgr.EmailsAPI.Models.Dtos;

namespace Matgr.EmailsAPI.Repository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(PaymentUpdateMessageDto messageDto);
    }
}
