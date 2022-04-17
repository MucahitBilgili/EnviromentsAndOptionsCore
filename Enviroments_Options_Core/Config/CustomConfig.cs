namespace Enviroments_Options_Core.Config
{
    public class CustomConfig
    {
        public string ConnectionString { get; set; }

        public EmailSetting EmailSettings { get; set; }

        public class EmailSetting
        {
            public string SMTPEmail { get; set; }
            public string SMTPPassWord { get; set; }
            public string SMTPPort { get; set; }
            public string SMTPHostname { get; set; }
        }
    }
}
