namespace BaseXamarin.Services
{
    using System;

    public class LogItem
    {
        public string Message { get; set; }

        public DateTimeOffset Date { get; set; }

        public string CallerMemberName { get; set; }
    }
}
