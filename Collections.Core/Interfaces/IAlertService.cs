using System;

namespace Collections.Core
{
    public interface IAlertService
    {
        void ShowAlert(string title, string message, string positivePromt, string negativePrompt, Action positiveAction = null, Action negativeAction = null);
    }
}
