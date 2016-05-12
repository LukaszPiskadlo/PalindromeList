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
    [Activity(Label = "Details")]
    public class DetailsActivity : Activity
    {
        string palindrome;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Details);

            int position = Intent.GetIntExtra("Position", 0);

            palindrome = MainActivity.Palindromes[position];

            FindViewById<TextView>(Resource.Id.palindromeName).Text = palindrome;
            FindViewById<TextView>(Resource.Id.palindromeLength).Text = "Length: " + palindrome.Length.ToString();

            FindViewById<Button>(Resource.Id.deleteButton).Click += OnDeleteClick;
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            var intent = new Intent();

            if(palindrome != null)
            {
                intent.PutExtra("ToDelete", palindrome);
                SetResult(Result.Ok, intent);
            }

            Finish();
        }
    }
}