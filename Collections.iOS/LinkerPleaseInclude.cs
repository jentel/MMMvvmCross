using System.Collections.ObjectModel;
using UIKit;

namespace Collections.Touch
{
    public class LinkerPleaseInclude
    {
        public void IncludeCollectionChanged()
        {
            var collection = new ObservableCollection<string>();
            collection.CollectionChanged += (sender, args) => { };
        }
    }
}