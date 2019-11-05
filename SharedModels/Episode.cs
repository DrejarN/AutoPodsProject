namespace SharedModels
{
    public class Episode
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int EpisodeNumber { get; set; }

        public Episode(string title, string description, int number)
        {
            this.Name = title;
            this.Description = description;
            this.EpisodeNumber = number;
        }
    }
}
