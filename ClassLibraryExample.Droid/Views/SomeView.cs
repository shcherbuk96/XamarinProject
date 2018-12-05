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
        private MvxRecyclerView _recyclerView;
        private SearchView _searchView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.my_recycler_view);
            _searchView = FindViewById<SearchView>(Resource.Id.search_some_view);

            var adapter = new MyAdapter((IMvxAndroidBindingContext)BindingContext);
            _recyclerView.Adapter = adapter;

            //searchView.QueryTextChange += (s, e) => Toast.MakeText(this, e.NewText, ToastLength.Short).Show();

            
            var set = this.CreateBindingSet<SomeView, MainViewModel>();
            set.Bind(adapter)
                .For(v => v.ItemsSource)
                .To(vm => vm.Lists);

            set.Bind(adapter)
                .For(v => v.ItemClick)
                .To(vm => vm.ClickCommand);

            set.Bind(_searchView)
                .For(v => v.Query)
                .To(vm => vm.SearchMessage);

            set.Apply();

            
        }
    }
}