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
    [Activity(Label = "Code")]
    public class ValidationActivity : Activity
    {
        TextView codeText;
        EditText codeInput;
        int code;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Validation);

            codeText = FindViewById<TextView>(Resource.Id.codeText);
            codeInput = FindViewById<EditText>(Resource.Id.codeInput);

            FindViewById<Button>(Resource.Id.validateButton).Click += OnValidationCLick;

            Random rng = new Random();
            code = rng.Next(100, 1000);

            codeText.Text = code.ToString();
        }

        private void OnValidationCLick(object sender, EventArgs e)
        {
            var intent = new Intent();
            int userCode = 0;

            if (!string.IsNullOrEmpty(codeInput.Text))
                userCode = int.Parse(codeInput.Text);

            if(userCode == code)
            {
                intent.PutExtra("Validation", true);
                SetResult(Result.Ok, intent);

                Finish();
            }
            else
            {
                intent.PutExtra("Validation", false);
                SetResult(Result.Canceled, intent);

                Finish();
            }
        }
    }
}