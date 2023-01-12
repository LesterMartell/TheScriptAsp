namespace TheScript_.Models
{
    public class Section : IBranch
    {
        public int Id_branch { get; set; }

        public Section(string title, int owner_branch) : base(title) 
        {
            Id_branch = owner_branch;
        }

        public Section(string title) : base(title)
        {
            
        }
    }
}
