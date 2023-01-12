namespace TheScript_.Models
{
    public class Chapter : IBranch
    {
        public int Id_branch { get; set; }
        public int Id_section { get; set; }
        public string HtmlText {get; set;}

        public Chapter(string title, int owner_section, int owner_branch, string text = "Empty text") : base(title) 
        {
            Id_branch = owner_branch;
            Id_section = owner_section;
            HtmlText = text;
        }

        public Chapter() : base() 
        {
            
        }
    }
}
