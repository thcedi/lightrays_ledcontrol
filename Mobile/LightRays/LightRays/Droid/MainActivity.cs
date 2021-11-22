using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using LightRays.Core;
using Prism;
using Prism.Ioc;
using System.Threading.Tasks;
//using Xamarin.Forms;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using LightRays.Core.Helper;
using Xamarin.Essentials;
using System.Linq;

namespace LightRays.Droid
{
    [Activity(Label = "LightRays", Icon = "@drawable/icon", Theme = "@style/splashscreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            UserDialogs.Init(this);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            await CheckAndRequestPermissions();
            LoadApplication(new App(new AndroidInitializer()));

            base.SetTheme(Resource.Style.MainTheme);

            Xamarin.Forms.MessagingCenter.Subscribe<object, object>(this, "ChangeToolbar", (sender, args) =>
            {
                ToolbarColorManager model = args as ToolbarColorManager;

                var toolbar = MainActivity.RootFindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
                if (toolbar == null) return;

                toolbar.SetBackground(new GradientDrawable(GradientDrawable.Orientation.RightLeft,
                    new int[] { model.LeftColor.ToAndroid(), model.RightColor.ToAndroid() }));
            });
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public async Task CheckAndRequestPermissions()
        {
            var perm = await Permissions.RequestAsync<Permissions.StorageRead>();

            var permissions = new PermissionStatus[]
            {
                await Permissions.RequestAsync<Permissions.StorageRead>(),
                await Permissions.RequestAsync<Permissions.StorageWrite>()
            };

            if(permissions.Any(p => p == PermissionStatus.Denied))
            {
                throw new System.Exception("Can't run without the appropriate permissions. Goodbye!");
            }
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