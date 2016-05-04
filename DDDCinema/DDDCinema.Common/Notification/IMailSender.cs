namespace DDDCinema.Common.Notifications
{
    public interface IMailSender
    {
        void SendMail(MailToSend mail);
    }
}
