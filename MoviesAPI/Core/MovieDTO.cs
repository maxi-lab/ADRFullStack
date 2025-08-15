namespace Core
{
    public class MovieDTO
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }      
    }
    public class MovieWithIdDTO : MovieDTO
    {
        public int Id { get; set; }
    }

}

