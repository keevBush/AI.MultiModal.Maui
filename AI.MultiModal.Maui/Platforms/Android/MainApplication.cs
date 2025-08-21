using Android.App;
using Android.Runtime;
using Authentication.Service;

namespace AI.MultiModal.Maui
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            FirebaseAuthInitializer.InitializeFirebase();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
