using System;

namespace Exercise1
{
    public class WelcomeInfo
    {
        public string DevelopedBy => "Vladimir Taranchuk";
        public string LinkedIn => @"https://www.linkedin.com/in/taranchuk/";
        public DateTime Now => DateTime.Now.ToLocalTime();

    }
}
