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
    [Activity(Label = "Add Palindrome")]
    public class AddActivity : Activity
    {
        Button saveButton;
        EditText inputText;
        TextView outputText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Add);

            inputText = FindViewById<EditText>(Resource.Id.inputPalindromeAdd);
            outputText = FindViewById<TextView>(Resource.Id.outputIsPalindromeAdd);
            saveButton = FindViewById<Button>(Resource.Id.saveButtonAdd);

            FindViewById<Button>(Resource.Id.cancelButtonAdd).Click += OnCancelClick;
            FindViewById<Button>(Resource.Id.checkButtonAdd).Click += OnCheckClick;
            saveButton.Click += OnSaveClick;

            saveButton.Enabled = false;
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            string palindrome = inputText.Text;
            var intent = new Intent();

            if(palindrome != null && IsPalindrome(palindrome))
            {
                intent.PutExtra("Palindrome", palindrome);
                SetResult(Result.Ok, intent);

                Finish();
            }
        }

        private void OnCheckClick(object sender, EventArgs e)
        {
            string palindrome = inputText.Text;

            if (palindrome != null)
            {
                if (IsPalindrome(palindrome))
                {
                    outputText.Text = "Yes, it is palindrome";
                    saveButton.Enabled = true;
                }
                else
                {
                    outputText.Text = "No, it isn't palindrome";
                    saveButton.Enabled = false;
                }
            }
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            Finish();
        }

        private bool IsPalindrome(string text)
        {
            string letters = null;

            text = text.ToLower().Trim();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                    letters += c;
            }

            if (letters == null)
                return false;

            char[] lettersReversed = letters.ToCharArray();
            Array.Reverse(lettersReversed);

            return letters.Equals(new string(lettersReversed));
        }
    }
}