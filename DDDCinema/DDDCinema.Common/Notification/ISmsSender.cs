namespace DDDCinema.Common.Notifications
{
    public interface ISmsSender
    {
        void SendSms(SmsToSend sms);
    }
}
