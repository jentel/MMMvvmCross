using Collections.Core.ViewModels.Samples.SmallFixed;
using MvvmCross.Core.ViewModels;

namespace Collections.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
		public void ShowMenu()
		{
            ShowViewModel<MainMenuViewModel>();
			ShowViewModel<SmallFixedViewModel>();
		}

		public void ShowHome()
		{
			ShowViewModel<MainMenuViewModel>();
		}

	}
}