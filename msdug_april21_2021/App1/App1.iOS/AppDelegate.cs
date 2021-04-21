using System;
using Foundation;
using UIKit;
using Shiny;

namespace App1.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            this.ShinyFinishedLaunching(new MyShinyStartup());
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }


        public override void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
            => this.ShinyPerformFetch(completionHandler);

        public override void HandleEventsForBackgroundUrl(UIApplication application, string sessionIdentifier, Action completionHandler)
            => this.ShinyHandleEventsForBackgroundUrl(sessionIdentifier, completionHandler);

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
            => this.ShinyRegisteredForRemoteNotifications(deviceToken);

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
            => this.ShinyFailedToRegisterForRemoteNotifications(error);

        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
            => this.ShinyDidReceiveRemoteNotification(userInfo, completionHandler);
    }
}









//[assembly: ShinyApplication(
//    ShinyStartupTypeName = "App1.MyShinyStartup",
//    XamarinFormsAppTypeName = "App1.App"
//)]