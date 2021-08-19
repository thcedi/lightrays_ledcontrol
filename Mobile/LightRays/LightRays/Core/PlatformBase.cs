using System;
using System.Globalization;
using Xamarin.Forms;

namespace LightRays.Core
{
    public abstract class PlatformBase : IPlatform
    {
        private int _keyboardTimerCount = 5;
        private bool _keyboardTimerIsRunning;

        public abstract string DataDirectory { get; }
        public abstract string DocumentsDirectory { get; }
        public string NotesDirectoryName { get; } = "Notes";
        public string NotificationsDirectoryName { get; } = "Notifications";
        public string TempDirectoryName { get; } = "Temp";
        public string ImportDirectoryName { get; } = "Import";
        public string ExportDirectoryName { get; } = "Export";
        public abstract string Build { get; }
        public string DatabaseFilenameSystem { get; } = "system.db";
        public string DatabaseFilenameTiles { get; } = "tiles.db";
        public abstract CultureInfo Culture { get; set; }
        public abstract string Name { get; }
        public abstract string Version { get; }

        public void KeyboardRefreshTimer(Entry entry)
        {
            _keyboardTimerCount = 5;

            if (_keyboardTimerIsRunning) return;
            _keyboardTimerIsRunning = true;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (_keyboardTimerCount == 0)
                {
                    KeyboardHide();
                    entry?.Unfocus();
                    _keyboardTimerIsRunning = false;
                    return false;
                }
                _keyboardTimerCount--;
                return true;
            });
        }

        public void KeyboardRefreshTimer()
        {
            _keyboardTimerCount = 5;
        }

        public abstract void CopyFileFromAssets(string filename, string targetpath);
        public abstract void OpenFile(string filename);
        public abstract void KeyboardHide();
    }

    public class PlatformCulture
    {
        public PlatformCulture(string platformCultureString)
        {
            if (string.IsNullOrEmpty(platformCultureString)) throw new ArgumentException("Expected culture identifier", nameof(platformCultureString));

            PlatformString = platformCultureString.Replace("_", "-"); // .NET erwartet dash statt underscore
            var dashIndex = PlatformString.IndexOf("-", StringComparison.Ordinal);
            if (dashIndex > 0)
            {
                var parts = PlatformString.Split('-');
                LanguageCode = parts[0];
                LocaleCode = parts[1];
            }
            else
            {
                LanguageCode = PlatformString;
                LocaleCode = "";
            }
        }

        public string LocaleCode { get; }

        public string PlatformString { get; }

        public string LanguageCode { get; }

        public override string ToString()
        {
            return PlatformString;
        }
    }

    public interface IPlatform
    {
        string Name { get; }
        string Version { get; }
        string Build { get; }
        string DataDirectory { get; }
        string DocumentsDirectory { get; }
        string NotesDirectoryName { get; }
        string NotificationsDirectoryName { get; }
        string TempDirectoryName { get; }
        string ImportDirectoryName { get; }
        string ExportDirectoryName { get; }
        string DatabaseFilenameSystem { get; }
        string DatabaseFilenameTiles { get; }

        CultureInfo Culture { get; set; }

        void CopyFileFromAssets(string filename, string targetpath);

        void OpenFile(string filename);

        void KeyboardHide();

        void KeyboardRefreshTimer(Entry entry);
        void KeyboardRefreshTimer();
    }
}
