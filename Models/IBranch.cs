namespace TheScript_.Models
{
    public class IBranch
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCreation {get; set;}
        public DateTime DateOfLastEdit {get; set;}

        public IBranch(string title = "Example")
        {
            Id = new int();
            Title = title;
            DateOfCreation = DateTime.Now;
            DateOfLastEdit = DateTime.Now;
        }
    }
}
