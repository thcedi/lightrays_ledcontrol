using Acr.UserDialogs;
using System;
using System.Threading.Tasks;

namespace LightRays.Core.Services
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);

        void ShowInfoToast(string title);

        Task<string> ShowSelectionAsync(string title, string cancel, string none, string[] items);

        Task<bool> ShowConfirmAsync(string message, string title, string buttonLabelOk, string buttonLabelCancel);

        Task<DatePromptResult> ShowDateTimePickerAsync(string title, DateTime dateMin, DateTime dateMax, DateTime dateSelected, string okText, string cancelText);

        Task<TimePromptResult> ShowTimePickerAsync(string title, int timeMin, int timeMax, TimeSpan timeSelected, bool use24HourClock, string okText, string cancelText);

        Task<LoginResult> ShowLoginAsync(string title, string message, string loginValue, string loginPlaceholder, string passwordPlaceholder, string okText, string cancelText);

        Task<PromptResult> ShowPromptAsync(PromptConfig config);

        void ShowActionSheet(ActionSheetConfig config);

        void ShowLoading(string title);

        void HideLoading();
    }
}