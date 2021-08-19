using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LightRays.Core;
using Plugin.Permissions;
using Prism;
using Prism.Ioc;
using System;
using System.Threading.Tasks;

namespace LightRays.Droid
{
    [Activity(Label = "LightRays", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            UserDialogs.Init(this);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
            base.OnCreate(savedInstanceState);
            await InitializePermissions();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetStatusBarColor(Android.Graphics.Color.Rgb(37, 37, 38));
            }

            LoadApplication(new App(new AndroidInitializer()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private async Task InitializePermissions()
        {
            var permissions = new Plugin.Permissions.Abstractions.Permission[] {
                Plugin.Permissions.Abstractions.Permission.Storage
            };

            bool allPermissionsGranted = await CheckPermissions(permissions);
            if (!allPermissionsGranted)
            {
                var result = await CrossPermissions.Current.RequestPermissionsAsync(permissions);

                if (await CheckPermissions(permissions) == false)
                    throw new System.Exception("LightRays can not continue without appropriate permissions! Goodbye.");
            }
        }

        private async Task<bool> CheckPermissions(Plugin.Permissions.Abstractions.Permission[] permissions)
        {
            bool result = true;
            for (int i = 0; i < permissions.Length; i++)
            {
                var isGranted = await CrossPermissions.Current.CheckPermissionStatusAsync(permissions[i]) == Plugin.Permissions.Abstractions.PermissionStatus.Granted;
                result = result && isGranted;
            }
            return result;
        }

        public class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                containerRegistry.RegisterSingleton(typeof(Core.IPlatform), typeof(PlatformDroid));
            }
        }
    }
}