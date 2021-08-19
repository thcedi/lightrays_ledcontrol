using Acr.UserDialogs;
using System;
using System.Threading.Tasks;

namespace LightRays.Core.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public Task<string> ShowSelectionAsync(string title, string cancel, string none, string[] items)
        {
            return UserDialogs.Instance.ActionSheetAsync(title, cancel, none, null, items);
        }

        public void ShowInfoToast(string title)
        {
            UserDialogs.Instance.Toast(title);
        }

        public Task<bool> ShowConfirmAsync(string message, string title, string buttonLabelOk, string buttonLabelCancel)
        {
            return UserDialogs.Instance.ConfirmAsync(message, title, buttonLabelOk, buttonLabelCancel);
        }

        public Task<DatePromptResult> ShowDateTimePickerAsync(string title, DateTime dateMin, DateTime dateMax, DateTime dateSelected, string okText, string cancelText)
        {
            var config = new DatePromptConfig()
            {
                Title = title,
                MinimumDate = dateMin,
                MaximumDate = dateMax,
                CancelText = cancelText,
                OkText = okText,
                SelectedDate = dateSelected
            };
            return UserDialogs.Instance.DatePromptAsync(config);
        }

        public Task<TimePromptResult> ShowTimePickerAsync(string title, int timeMin, int timeMax, TimeSpan timeSelected, bool use24HourClock, string okText, string cancelText)
        {
            var config = new TimePromptConfig()
            {
                Title = title,
                MinimumMinutesTimeOfDay = timeMin,
                MaximumMinutesTimeOfDay = timeMax,
                SelectedTime = timeSelected,
                Use24HourClock = use24HourClock,
                OkText = okText,
                CancelText = cancelText
            };
            return UserDialogs.Instance.TimePromptAsync(config);
        }

        public Task<LoginResult> ShowLoginAsync(string title, string message, string loginValue, string loginPlaceholder, string passwordPlaceholder, string okText, string cancelText)
        {
            var config = new LoginConfig()
            {
                Title = title,
                Message = message,
                LoginValue = loginValue,
                LoginPlaceholder = loginPlaceholder,
                PasswordPlaceholder = passwordPlaceholder,
                OkText = okText,
                CancelText = cancelText
            };
            return UserDialogs.Instance.LoginAsync(config);
        }

        public Task<PromptResult> ShowPromptAsync(PromptConfig config)
        {
            return UserDialogs.Instance.PromptAsync(config);
        }

        public void ShowActionSheet(ActionSheetConfig config)
        {
            UserDialogs.Instance.ActionSheet(config);
        }

        public void ShowLoading(string title)
        {
            UserDialogs.Instance.ShowLoading(title);
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}