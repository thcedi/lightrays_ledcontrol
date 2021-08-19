using Foundation;
using LightRays.Core;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using UIKit;

namespace LightRays.iOS
{
    internal class PlatformiOS : PlatformBase
    {
        private CultureInfo _culture;

        public PlatformiOS()
        {
            // Cleanup the temp directory
            Directory.Delete(Path.Combine(DocumentsDirectory, TempDirectoryName), true);
        }

        public override string DataDirectory
        {
            get
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
                return path;
            }
        }

        public override string DocumentsDirectory
        {
            get
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var pathNotes = Path.Combine(path, base.NotesDirectoryName);
                var pathNotifications = Path.Combine(path, base.NotificationsDirectoryName);
                var pathTemp = Path.Combine(path, base.TempDirectoryName);
                var pathImport = Path.Combine(path, base.ImportDirectoryName);
                var pathExport = Path.Combine(path, base.ExportDirectoryName);

                if (!Directory.Exists(pathNotes)) Directory.CreateDirectory(pathNotes);
                if (!Directory.Exists(pathNotifications)) Directory.CreateDirectory(pathNotifications);
                if (!Directory.Exists(pathTemp)) Directory.CreateDirectory(pathTemp);
                if (!Directory.Exists(pathImport)) Directory.CreateDirectory(pathImport);
                if (!Directory.Exists(pathExport)) Directory.CreateDirectory(pathExport);

                return path;
            }
        }

        public override string Build
        {
            get
            {
                return NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();
            }
        }

        public override CultureInfo Culture
        {
            get
            {
                // Use the already cached culture
                if (_culture != null) return _culture;

                var netLanguage = "en";
                if (NSLocale.PreferredLanguages.Length > 0)
                {
                    var pref = NSLocale.PreferredLanguages[0];
                    netLanguage = TransformLanguageFromiOSToDotnet(pref);
                }

                try
                {
                    _culture = new CultureInfo(netLanguage);
                }
                catch (CultureNotFoundException)
                {
                    // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                    // fallback to first characters, in this case "en"
                    try
                    {
                        var fallback = TransformLanguageToDotnetFallback(new PlatformCulture(netLanguage));
                        _culture = new CultureInfo(fallback);
                    }
                    catch (CultureNotFoundException)
                    {
                        // iOS language not valid .NET culture, falling back to English
                        _culture = new CultureInfo("en");
                    }
                }

                return _culture;
            }
            set
            {
                Thread.CurrentThread.CurrentCulture = value;
                Thread.CurrentThread.CurrentUICulture = value;
            }
        }

        public override string Name { get { return "iOS"; } }

        public override string Version
        {
            get
            {
                return NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleShortVersionString")].ToString();
            }
        }

        public override void CopyFileFromAssets(string filename, string targetpath)
        {
            if (File.Exists(targetpath)) return;

            int index = filename.LastIndexOf(".");
            string type = filename.Substring(index);
            string name = filename.Substring(0, index);

            var existingDb = NSBundle.MainBundle.PathForResource(name, type);
            File.Copy(existingDb, targetpath);
        }

        public override void OpenFile(string filePath)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl(filePath));
        }

        public override void KeyboardHide()
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;
                }

                vc.View.EndEditing(true);
            });
        }

        private string TransformLanguageFromiOSToDotnet(string iOSLanguage)
        {
            Console.WriteLine("iOS Language:" + iOSLanguage);
            var netLanguage = iOSLanguage;

            //certain languages need to be converted to CultureInfo equivalent
            switch (iOSLanguage)
            {
                case "ms-MY":   // "Malaysian (Malaysia)" not supported .NET culture
                case "ms-SG":   // "Malaysian (Singapore)" not supported .NET culture
                    netLanguage = "ms"; // closest supported
                    break;

                case "gsw-CH":  // "Schwiizertüütsch (Swiss German)" not supported .NET culture
                    netLanguage = "de-CH"; // closest supported
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }

            Console.WriteLine(".NET Language/Locale:" + netLanguage);
            return netLanguage;
        }

        private string TransformLanguageToDotnetFallback(PlatformCulture platformCulture)
        {
            Console.WriteLine(".NET Fallback Language:" + platformCulture.LanguageCode);
            var netLanguage = platformCulture.LanguageCode; // use the first part of the identifier (two chars, usually);

            switch (platformCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT"; // fallback to Portuguese (Portugal)
                    break;

                case "gsw":
                    netLanguage = "de-CH"; // equivalent to German (Switzerland) for this app
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }

            Console.WriteLine(".NET Fallback Language/Locale:" + netLanguage + " (application-specific)");
            return netLanguage;
        }
    }
}