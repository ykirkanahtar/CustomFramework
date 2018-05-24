namespace CustomFramework.EmailProvider
{
    public class EmailConfig
    {
        public string MailServer { get; set; }
        public int MailServerPort { get; set; }
        public bool EnableSsl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
