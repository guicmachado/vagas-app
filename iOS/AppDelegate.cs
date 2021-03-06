﻿using Foundation;
using UIKit;

namespace VagasApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			return base.FinishedLaunching(app, options);
		}
	}
}
