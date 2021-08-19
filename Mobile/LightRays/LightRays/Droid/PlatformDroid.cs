using Android.Content;
using Android.Support.V4.Content;
using Android.Views.InputMethods;
using LightRays.Core;
using Plugin.CurrentActivity;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using Xamarin.Forms;

namespace LightRays.Droid
{
    internal class PlatformDroid : PlatformBase
    {
        private CultureInfo _culture;
        private Context _context;

        public PlatformDroid()
        {
            // Cleanup the temp directory
            Directory.Delete(Path.Combine(DocumentsDirectory, TempDirectoryName), true);

            // Set the activity for the xaml designers
            if (!DesignMode.IsDesignModeEnabled)
            {
                _context = CrossCurrentActivity.Current.Activity.ApplicationContext;
            }
        }

        public override string Name { get { return "Android"; } }

        public override string Version
        {
            get
            {
                return _context.PackageManager.GetPackageInfo(_context.PackageName, 0).VersionName.Split(' ')[0];
            }
        }

        public override string Build
        {
            get
            {
                return _context.PackageManager.GetPackageInfo(_context.PackageName, 0).VersionCode.ToString();
            }
        }

        public override string DataDirectory
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
        }

        public override string DocumentsDirectory
        {
            get
            {
                var path = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "LightRays");
                var pathNotes = Path.Combine(path, base.NotesDirectoryName);
                var pathNotifications = Path.Combine(path, base.NotificationsDirectoryName);
                var pathTemp = Path.Combine(path, base.TempDirectoryName);
                var pathImport = Path.Combine(path, base.ImportDirectoryName);
                var pathExport = Path.Combine(path, base.ExportDirectoryName);

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                if (!Directory.Exists(pathNotes)) Directory.CreateDirectory(pathNotes);
                if (!Directory.Exists(pathNotifications)) Directory.CreateDirectory(pathNotifications);
                if (!Directory.Exists(pathTemp)) Directory.CreateDirectory(pathTemp);
                if (!Directory.Exists(pathImport)) Directory.CreateDirectory(pathImport);
                if (!Directory.Exists(pathExport)) Directory.CreateDirectory(pathExport);

                return path;
            }
        }

        public override CultureInfo Culture
        {
            get
            {
                // Use the already cached culture
                if (_culture != null) return _culture;

                var netLanguage = "en";
                var androidLocale = Java.Util.Locale.Default;
                netLanguage = TransformLanguageFromAndroidToDotnet(androidLocale.ToString().Replace("_", "-"));

                try
                {
                    _culture = new CultureInfo(netLanguage);
                }
                catch (CultureNotFoundException)
                {
                    // Droid locale not valid .NET culture (eg. "en-ES" : English in Spain) fallback to first characters, in this case "en"
                    try
                    {
                        var fallback = TransformLanguageToDotnetFallback(new PlatformCulture(netLanguage));
                        _culture = new CultureInfo(fallback);
                    }
                    catch (CultureNotFoundException)
                    {
                        // Droid language not valid .NET culture, falling back to English
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

        public override void CopyFileFromAssets(string filename, string targetpath)
        {
            if (File.Exists(targetpath)) return;

            using (var br = new BinaryReader(_context.Assets.Open(filename)))
            {
                using (var bw = new BinaryWriter(new FileStream(targetpath, FileMode.Create)))
                {
                    var buffer = new byte[2048];
                    int length = 0;
                    while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bw.Write(buffer, 0, length);
                    }
                }
            }
        }

        public override void OpenFile(string filePath)
        {
            Android.Net.Uri uri = FileProvider.GetUriForFile(_context, "de.lacos.LightRays.fileprovider", new Java.IO.File(filePath));
            Intent intent = new Intent(Intent.ActionView);
            intent.SetData(uri);
            intent.SetFlags(ActivityFlags.GrantReadUriPermission);

            _context.StartActivity(intent);
        }

        private string TransformLanguageFromAndroidToDotnet(string androidLanguage)
        {
            Console.WriteLine("Android Language:" + androidLanguage);
            var netLanguage = androidLanguage;

            //certain languages need to be converted to CultureInfo equivalent
            switch (androidLanguage)
            {
                case "ms-BN":   // "Malaysian (Brunei)" not supported .NET culture
                case "ms-MY":   // "Malaysian (Malaysia)" not supported .NET culture
                case "ms-SG":   // "Malaysian (Singapore)" not supported .NET culture
                    netLanguage = "ms"; // closest supported
                    break;
                case "in-ID":  // "Indonesian (Indonesia)" has different code in  .NET 
                    netLanguage = "id-ID"; // correct code for .NET
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
                case "gsw":
                    netLanguage = "de-CH"; // equivalent to German (Switzerland) for this app
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }

            Console.WriteLine(".NET Fallback Language/Locale:" + netLanguage + " (application-specific)");
            return netLanguage;
        }

        public override void KeyboardHide()
        {
            InputMethodManager imm = InputMethodManager.FromContext(_context);
            imm.HideSoftInputFromWindow(CrossCurrentActivity.Current.Activity.Window.DecorView.WindowToken, HideSoftInputFlags.NotAlways);
        }
    }
}