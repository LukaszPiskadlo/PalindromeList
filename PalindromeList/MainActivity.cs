using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace PalindromeList
{
    [Activity(Label = "PalindromeList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static List<string> Palindromes = new List<string>();
        Button listButton;

        public static bool Unlocked { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            listButton = FindViewById<Button>(Resource.Id.listButtonMain);

            listButton.Click += OnListClick;
            FindViewById<Button>(Resource.Id.addButtonMain).Click += OnAddClick;
            FindViewById<Button>(Resource.Id.aboutButtonMain).Click += OnAboutClick;

            Unlocked = false;
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (Palindromes.Count > 0)
                listButton.Enabled = true;
            else
                listButton.Enabled = false;
        }

        private void OnListClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(PalindromesActivity));
            StartActivity(intent);
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddActivity));
            StartActivityForResult(intent, 1);
        }

        private void OnAboutClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if(resultCode == Result.Ok && requestCode == 1)
                Palindromes.Add(data.GetStringExtra("Palindrome"));
        }
    }
}

