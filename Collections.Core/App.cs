using Collections.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace Collections.Core
{
    public class App
        : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainMenuViewModel>();
        }
    }
}