﻿using Android.App;
using Android.OS;
using Android.Widget;
using ClassLibraryExample.Core.Pojo;
using ClassLibraryExample.Core.ViewModels;
using ClassLibraryExample.Droid.Adapter;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace ClassLibraryExample.Droid.Views
{
    [Activity(Label = "SomeView")]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
        private MvxRecyclerView _recyclerView;
        private SearchView _searchView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.my_recycler_view);
            _searchView = FindViewById<SearchView>(Resource.Id.search_some_view);

            var adapter = new MainAdapter((IMvxAndroidBindingContext) BindingContext, OnCommand);
            _recyclerView.Adapter = adapter;

            var set = this.CreateBindingSet<MainView, MainViewModel>();

            set.Bind(adapter)
                .For(v => v.ItemsSource)
                .To(vm => vm.Lists);

            set.Bind(_searchView)
                .For(v => v.Query)
                .To(vm => vm.SearchMessage);

            set.Apply();
        }

        public void OnCommand(HitModel hitModel)
        {
            ViewModel?.ClickItemCommand.Execute(hitModel);
        }

        public override void OnBackPressed()
        {
           
        }
    }
}