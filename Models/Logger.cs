namespace TheScript_.Models
{
    public class Logger
    {
        public int Id { get; set; }
        public DateTime Date {get; set;}
        public string Info {get; set;}

        public Logger(string info)
        {
            Info = info;
            Date = DateTime.Now;
            Id = new int();
        }
    }
}
