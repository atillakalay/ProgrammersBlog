using Core.Utilities.Results.Abstract;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IMailService
    {
        IResult Send(EmailSendDto emailSendDto);
        IResult SendContactEmail(EmailSendDto emailSendDto);
    }
}
