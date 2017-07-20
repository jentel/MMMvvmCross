using System;
using MvvmCross.Core.ViewModels;

namespace Collections.Core
{
    public class SimpleBioPageViewModel : MvxViewModel
    {
        public SimpleBioPageViewModel()
        {
            Random _random = new Random();

            KittenInformation = new BioInfo("Fluffy", "Likes to bite", string.Format("http://placekitten.com/{0}/{0}", _random.Next(20) + 300));
        }

        public BioInfo KittenInformation { get; private set; }

        public class BioInfo
        {
            public string Name { get; private set; }
            public string Bio { get; private set; }
            public string ImageUrl { get; private set; }

            public BioInfo(string name, string bio, string image)
            {
                Name = name;
                Bio = bio;
                ImageUrl = image;
            }
        }
    }
}
