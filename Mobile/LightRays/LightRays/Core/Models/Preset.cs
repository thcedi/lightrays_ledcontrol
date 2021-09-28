using SQLite;
using System.ComponentModel;

namespace LightRays.Core.Models
{
    public class Preset : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
