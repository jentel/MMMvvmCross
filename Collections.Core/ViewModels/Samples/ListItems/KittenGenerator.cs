using System;
using System.Collections.Generic;

namespace Collections.Core.ViewModels.Samples.ListItems
{
	public class KittenGenerator
    {
		private readonly List<string> _typesOfKittens = new List<string>
		{
			"Fluffy",
			"ReallyFluffy",
			"Scrappy",
			"Cute",
			"Aggressive",
			"Funny",
			"Bald",
			"WillBite",
			"HasBigPaws"
		};

        private readonly List<string> _names = new List<string>
            {
                "Tiddles",
                "Amazon",
                "Pepsi",
                "Solomon",
                "Butler",
                "Snoopy",
                "Harry",
                "Holly",
                "Paws",
                "Polly",
                "Dixie",
                "Fern",
                "Cousteau",
                "Frankenstein",
                "Bazooka",
                "Casanova",
                "Fudge",
                "Comet"
            };

        /// <summary>
        /// Courtesy of http://www.springhole.net/writing_roleplaying_randomators/catcreator.htm
        /// </summary>
        private readonly List<string> _info = new List<string>
			{
				"Fond of fish, is very excitable, and will jump on any available lap. ",
				"Especially fond of chicken, is a bit lazy, and will jump on any available lap.",
				"Especially fond of fish, is a bit excitable, and is very friendly.",
				"Especially fond of beef, is very excitable, and is very shy.",
				"Especially fond of beef, is a bit lazy, and is very shy.",
				"Is a picky eater, is a bit excitable, and is cautious around strangers.",
				"Especially fond of fish, is very lazy, and is cautious around strangers.",
				"Is a picky eater, is very lazy, and is very shy.",
				"Especially fond of chicken, pounces anything that moves, and is very friendly.",
				"Is a picky eater, is very excitable, and is very friendly.",
				"Will eat almost anything in sight, is very lazy, and will jump on any available lap.",
				"Is a picky eater, is very playful, and will jump on any available lap.",
				"Is a picky eater, is a bit lazy, and is cautious around strangers.",
				"Is a picky eater, is a bit lazy, and prefers to be left alone.",
				"Especially fond of fish, is very lazy, and prefers to be left alone.",
				"Especially fond of chicken, is very lazy, and will jump on any available lap.",
				"Especially fond of fish, is very playful, and is very friendly.",
				"Will eat almost anything in sight, is a bit excitable, and is cautious around strangers.",
                "Is not a picky eater, is very friendly, but likes to bite."
            };


        private readonly Random _random = new Random();

        public Kitten CreateNewKitten()
        {
            return new Kitten
            {
                Name = _names[_random.Next(_names.Count)],
                ImageUrl = string.Format("http://placekitten.com/{0}/{0}", _random.Next(20) + 300),
                Bio = _info[_random.Next(_info.Count)]
            };
        }

		public KittenGroup CreateNewKittenGroup(int numberOfKittens)
		{
			var kittenList = new List<Kitten>();
			for (int x = 0; x < numberOfKittens; x++)
			{
				kittenList.Add(CreateNewKitten());
			}

			return new KittenGroup(kittenList)
			{
				Title = _typesOfKittens[_random.Next(_typesOfKittens.Count)]
			};
		}
    }
}