using Android.App;
using Android.OS;
using Android.Widget;
using ClassLibraryExample.Core.Pojo;
using ClassLibraryExample.Core.ViewModels;
using ClassLibraryExample.Droid.PhotosRecyclerView;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace ClassLibraryExample.Droid.Views
{
    [Activity(Label = "PhotosView")]
    public class PhotosView : MvxAppCompatActivity<PhotosViewModel>
    {
        private MvxRecyclerView _recyclerView;
        private EditText _searchEdt;
        private Button _searchButton;

        public void Binding(PhotosAdapter adapter)
        {
            var set = this.CreateBindingSet<PhotosView, PhotosViewModel>();

            set.Bind(adapter)
                .For(v => v.ItemsSource)
                .To(vm => vm.Lists);

            set.Bind(_searchEdt)
                .For(v => v.Text)
                .To(vm => vm.SearchMessage);

            set.Bind(_searchButton)
                .To(vm => vm.ClickSearchCommand);

            set.Apply();
        }
        public void OnCommand(HitModel hitModel)
        {
            ViewModel?.ClickItemCommand.Execute(hitModel);
        }

        public override void OnBackPressed()
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_photos);
            
            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recycler_photos_view);
            _searchEdt = FindViewById<EditText>(Resource.Id.search_photos_view);
            _searchButton = FindViewById<Button>(Resource.Id.search_btn_photos_view);

            var adapter = new PhotosAdapter((IMvxAndroidBindingContext) BindingContext, OnCommand);
            _recyclerView.Adapter = adapter;

            Binding(adapter);
       
        }
    }
}