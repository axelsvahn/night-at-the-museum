namespace museet
{
    ///<summary>
    ///Represents an artwork in a room; stored in list within each Room
    ///</summary>
    public class Artwork
    {
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Description { get; set; }
        
        public Artwork(string title, string creator, string description )
        {
            Title = title;
            Creator = creator;
            Description = description; 
        }

        public override string ToString()
        {  
            return $"Titel: {Title}\nUpphovsmakare: {Creator}\nBeskrivning: {Description}\n";
        }
    }
}
