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
    [Activity(Label = "Palindromes")]
    public class PalindromesActivity : Activity
    {
        ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Palindromes);

            listView = FindViewById<ListView>(Resource.Id.listView);

            listView.ItemClick += OnItemClick;
        }

        protected override void OnStart()
        {
            base.OnStart();

            listView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, MainActivity.Palindromes);
            if (listView.Adapter.IsEmpty)
                Finish();
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int position = e.Position;
            var intent = new Intent(this, typeof(DetailsActivity));

            intent.PutExtra("Position", position);

            StartActivityForResult(intent, 2);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok && requestCode == 2)
                MainActivity.Palindromes.Remove(data.GetStringExtra("ToDelete"));
        }
    }
}