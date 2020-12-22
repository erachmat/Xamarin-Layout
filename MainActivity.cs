using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin_Layout.Model;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Xamarin_Layout.Adapter;

namespace Xamarin_Layout
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView recyclerView;
        TextView txtJudul;
        AdapterHome adapterHome;
        List<ItemHome> itemList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitData();
            InitView();
            SetData();
        }

        private void SetData()
        {
            adapterHome = new AdapterHome(this, itemList);

            recyclerView.HasFixedSize = true;

            GridLayoutManager gridLayoutManager = new GridLayoutManager(this, Common.NUM_OF_COLUMNS);
            gridLayoutManager.Orientation = RecyclerView.Vertical;
            gridLayoutManager.SetSpanSizeLookup(new HomeSpanSizeLookup(adapterHome));

            recyclerView.SetLayoutManager(gridLayoutManager);
            recyclerView.AddItemDecoration(new SpacesItemDecoration(8));
            recyclerView.SetAdapter(adapterHome);
        }

        private void InitView()
        {
            recyclerView = FindViewById<RecyclerView>(Resource.Id.rvHome);
        }

        private void InitData()
        {
            itemList = new List<ItemHome>();

            itemList.Add(new ItemHome(Resource.Drawable.man, "person"));
            itemList.Add(new ItemHome(Resource.Drawable.employees, "couple"));
            itemList.Add(new ItemHome(Resource.Drawable.Myteam, "team"));
            itemList.Add(new ItemHome(Resource.Drawable.group, "family"));
            itemList.Add(new ItemHome(Resource.Drawable.calendar, "calendar"));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private class HomeSpanSizeLookup : GridLayoutManager.SpanSizeLookup
        {
            private AdapterHome adapterHome;

            public HomeSpanSizeLookup(AdapterHome adapterHome)
            {
                this.adapterHome = adapterHome;
            }

            public override int GetSpanSize(int position)
            {
                switch (adapterHome.GetItemViewType(position))
                {
                    case 1: return 1;
                    case 0: return Common.NUM_OF_COLUMNS;
                    default: return -1;
                }
            }
        }
    }
}