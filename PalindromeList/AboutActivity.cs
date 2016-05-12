using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PalindromeList
{
    [Activity(Label = "About")]
    public class AboutActivity : Activity
    {
        Button siteButton;
        Button locationButton;
        Button unlockButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.About);

            siteButton = FindViewById<Button>(Resource.Id.siteButton);
            locationButton = FindViewById<Button>(Resource.Id.locationButton);
            unlockButton = FindViewById<Button>(Resource.Id.unlockButton);

            siteButton.Click += OnSiteClick;
            locationButton.Click += OnLocationClick;
            unlockButton.Click += OnUnlockClick;
        }

        protected override void OnStart()
        {
            base.OnStart();

            if(MainActivity.Unlocked)
            {
                siteButton.Enabled = true;
                locationButton.Enabled = true;
                unlockButton.Enabled = false;
            }
            else
            {
                siteButton.Enabled = false;
                locationButton.Enabled = false;
                unlockButton.Enabled = true;
            }
        }

        private void OnLocationClick(object sender, EventArgs e)
        {
            var intent = new Intent();

            intent.SetAction(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse("geo:53.4481936,14.4909271?z=18.5"));

            if(intent.ResolveActivity(PackageManager) != null)
                StartActivity(intent);
            else
                Finish();
        }

        private void OnSiteClick(object sender, EventArgs e)
        {
            var intent = new Intent();

            intent.SetAction(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse("http://dotnet.zut.edu.pl"));

            StartActivity(intent);
        }

        private void OnUnlockClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ValidationActivity));
            StartActivityForResult(intent, 3);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok && requestCode == 3)
            {
                if(data.GetBooleanExtra("Validation", false))
                {
                    MainActivity.Unlocked = true;
                }
            }
        }
    }
}