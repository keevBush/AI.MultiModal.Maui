using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.MultiModal.Maui.Platforms.Android
{
    public class NotificationManagerService : INotificationManagerService
    {
        const string channelId = "default";
        const string channelName = "Default";
        const string channelDescription = "The default channel for notifications.";

        public const string TitleKey = "title";
        public const string MessageKey = "message";

        bool _channelInitialized = false;
        int _messageId = 0;
        int _pendingIntentId = 0;

        NotificationManagerCompat compatManager;

        public event EventHandler NotificationReceived;

        public static NotificationManagerService Instance { get; private set; }

        public NotificationManagerService()
        {
            if (Instance == null)
            {
                CreateNotificationChannel();
                compatManager = NotificationManagerCompat.From(Platform.AppContext);
                Instance = this;
            }
        }


        void CreateNotificationChannel()
        {
            // Create the notification channel, but only on API 26+.
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelNameJava = new Java.Lang.String(channelName);
                var channel = new NotificationChannel(channelId, channelNameJava, NotificationImportance.Default)
                {
                    Description = channelDescription
                };
                // Register the channel
                NotificationManager manager = (NotificationManager)Platform.AppContext.GetSystemService(Context.NotificationService);
                manager.CreateNotificationChannel(channel);
                _channelInitialized = true;
            }
        }

        long GetNotifyTime(DateTime notifyTime)
        {
            DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(notifyTime);
            double epochDiff = (new DateTime(1970, 1, 1) - DateTime.MinValue).TotalSeconds;
            long utcAlarmTime = utcTime.AddSeconds(-epochDiff).Ticks / 10000;
            return utcAlarmTime; // milliseconds
        }

    }
}
