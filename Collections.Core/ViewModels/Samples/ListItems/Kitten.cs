using System.ComponentModel;

namespace Collections.Core.ViewModels.Samples.ListItems
{
    public class Kitten : Animal, INotifyPropertyChanged
    {
        private string _name;
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            } 
        }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
        public bool IsNavigation { get; set; }
        public int Index { get; set; }
        public int Age { get; set; }
        public bool ShouldPopUp { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this,
					new PropertyChangedEventArgs(propertyName));
			}
		}
    }
}