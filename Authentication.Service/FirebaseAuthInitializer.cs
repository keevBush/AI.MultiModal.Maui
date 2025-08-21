using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service
{
    public class FirebaseAuthInitializer
    {
        public static void InitializeFirebase()
        {
#if ANDROID
            if(DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                Firebase.FirebaseApp.InitializeApp(Android.App.Application.Context);
            }
#endif
        }
    }
}
