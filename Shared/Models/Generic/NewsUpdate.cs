namespace OptechX.Portal.Shared.Models.Generic
{
	public class NewsUpdate
	{
		public int Id { get; set; }
		public string Image { get; set; } = null!;
		public string Heading { get; set; } = null!;
        public string Preview { get; set; } = null!;
        public string Link { get; set; } = null!;
    }
}

