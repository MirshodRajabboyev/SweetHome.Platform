using SweetHome.Service.Dtos.Notification;

namespace SweetHome.Service.Interfaces.Notification;

public interface ISmsSender
{
    public Task<bool> SendsmsAsync(SmsMessage smsMessage);

}
