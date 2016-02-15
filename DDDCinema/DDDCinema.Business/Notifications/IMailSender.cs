namespace DDDCinema.Movies.Notifications
{
    public interface IMailSender
    {
        void SendMail(MailToSend mail);
    }
}
