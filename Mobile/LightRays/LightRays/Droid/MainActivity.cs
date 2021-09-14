using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using LightRays.Core;
using Plugin.Permissions;
using Prism;
using Prism.Ioc;
using System.Threading.Tasks;
//using Xamarin.Forms;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;

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

            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                //Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                //Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                //Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);
                ////Window.SetStatusBarColor(Android.Graphics.Color.Transparent);


            }

            LoadApplication(new App(new AndroidInitializer()));

            Xamarin.Forms.MessagingCenter.Subscribe<object, object>(this, "ChangeToolbar", (sender, args) =>
            {
                LightRays.Core.ViewModels.MainPageViewModel.ToolbarColorManager model = args as LightRays.Core.ViewModels.MainPageViewModel.ToolbarColorManager;

                var toolbar = MainActivity.RootFindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
                if (toolbar == null) return;

                toolbar.SetBackground(new GradientDrawable(GradientDrawable.Orientation.RightLeft,
                    new int[] { model.LeftColor.ToAndroid(), model.RightColor.ToAndroid() }));
            });
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private async Task InitializePermissions()
        {
            //var permissions = new Plugin.Permissions.Abstractions.Permission[] {
            //    Plugin.Permissions.Abstractions.Permission.Storage
            //};

            //bool allPermissionsGranted = await CheckPermissions(permissions);
            //if (!allPermissionsGranted)
            //{
            //    var result = await CrossPermissions.Current.RequestPermissionsAsync(permissions);

            //    if (await CheckPermissions(permissions) == false)
            //        throw new System.Exception("LightRays can not continue without appropriate permissions! Goodbye.");
            //}
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

        private static MainActivity instance;

        public static View RootFindViewById<T>(int id) where T : View
        {
            return instance.FindViewById<T>(id);
        }

        public MainActivity()
        {
            instance = this;
        }
    }
}