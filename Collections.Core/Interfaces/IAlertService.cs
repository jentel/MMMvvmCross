using System;
using System.Threading.Tasks;

namespace Collections.Core
{
    public interface IAlertService
    {
        Task<bool> ShowAlert(string title, string prompt, string positivePromt, string negativePrompt, int x);



        void ShowAlert(string title, string message, string positivePromt, string negativePrompt, Action positiveAction = null, Action negativeAction = null);
    }

    //public class InputResults
    //{
    //    public InputResults(string result, bool cancelled)
    //    {
    //        Result = result;
    //        Cancelled = cancelled;
    //    }

    //    public string Result { get; private set; }
    //    public bool Cancelled { get; private set; }
    //}
}
