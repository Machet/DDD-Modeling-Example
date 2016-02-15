namespace DDDCinema.Movies.Notifications
{
    public interface ISmsSender
    {
        void SendSms(SmsToSend sms);
    }
}
