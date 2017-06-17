﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Gcm.Client;
using VagasApp.Droid.Services;

namespace VagasApp.Droid
{
	
	[Activity(Label = "VagasApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		// Create a new instance field for this activity.
		static MainActivity instance = null;
		// Return the current activity instance. 
		public static MainActivity CurrentActivity
		{
			get
			{
				return instance;
			}
		}
		// Flag to enable notification
		private const bool NotificationFlag = false;

		protected override void OnCreate(Bundle bundle)
		{
			// Set the current instance of MainActivity.
			instance = this;

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			LoadApplication(new App());

			if (NotificationFlag)
			{
				try
				{
					// Check to ensure everything's set up right
					GcmClient.CheckDevice(this);
					GcmClient.CheckManifest(this);
					// Register for push notifications
					System.Diagnostics.Debug.WriteLine("Registering...");
					GcmClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
				}
				catch (Java.Net.MalformedURLException)
				{
					CreateAndShowDialog("There was an error creating the client. Verify the URL.", "Error");
				}
				catch (Exception e)
				{
					CreateAndShowDialog(e.Message, "Error");
				}	
			}

		}

		private void CreateAndShowDialog(String message, String title)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder.SetMessage(message);
			builder.SetTitle(title);
			builder.Create().Show();
		}
	}
}
