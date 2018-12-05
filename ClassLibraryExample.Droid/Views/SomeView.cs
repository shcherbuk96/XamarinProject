using Android.App;
using Android.OS;
using Android.Widget;
using ClassLibraryExample.Core;
using ClassLibraryExample.Droid.Adapter;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace ClassLibraryExample.Droid.Views
{
    [Activity(Label = "SomeView")]
    public class SomeView : MvxAppCompatActivity<MainViewModel>
    {
        MvxRecyclerView recyclerView;
        SearchView searchView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.my_recycler_view);
            searchView = FindViewById<SearchView>(Resource.Id.search_some_view);

            var adapter = new MyAdapter((IMvxAndroidBindingContext)this.BindingContext);
            recyclerView.Adapter = adapter;

            //searchView.QueryTextChange += (s, e) => Toast.MakeText(this, e.NewText, ToastLength.Short).Show();

            
            var set = this.CreateBindingSet<SomeView, MainViewModel>();
            set.Bind(adapter)
                .For(v => v.ItemsSource)
                .To(vm => vm.Lists);

            set.Bind(adapter)
                .For(v => v.ItemClick)
                .To(vm => vm.ClickCommand);

            set.Bind(searchView)
                .For(v => v.Query)
                .To(vm => vm.SearchMessage);

            set.Apply();

            
        }
    }
}