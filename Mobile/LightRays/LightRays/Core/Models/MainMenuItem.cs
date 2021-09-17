namespace LightRays.Core.Models
{
    public class MainMenuItem
    {
        public int Id { get; set; }
        public int ParentId { get; set; } = -1;
        public string Title { get; set; }
        public string Target { get; set; }
        public bool HasChilds { get; set; }
        public bool ShowChilds { get; set; }
        public bool IsSelected { get; set; }
        public Xamarin.Forms.Color BackgroundColor { get; set; }
    }
}
