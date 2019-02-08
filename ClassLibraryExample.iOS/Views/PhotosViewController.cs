using System;
using Blank.PhotosTableView;
using ClassLibraryExample.Core.Pojo;
using ClassLibraryExample.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Binding.Views.Gestures;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace Blank.Views
{
    public class PhotosViewController : MvxViewController<PhotosViewModel>
    {
        public new PhotosView View
        {
            get => (PhotosView)base.View;
            set => base.View = value;
        }

        public override void ViewDidLoad()
        {
            View = new PhotosView();

            base.ViewDidLoad();
            View.BackgroundColor=UIColor.White;
            Title = "Person Target details";

            View.CollectionView.RegisterClassForCell(typeof(PhotosCell), PhotosCell.Key);

           // View.SearchBar.SearchButtonClicked += SearchOnClick;


            var set = this.CreateBindingSet<PhotosViewController, PhotosViewModel>();
            set.Bind(View.PhotosTableViewSource).For(v=>v.ItemsSource).To(vm => vm.ListHits);
            set.Bind(View.SearchBar).For(v=>v.Text).To(vm => vm.SearchMessage);
            set.Bind(View.SearchBar).For("SearchButtonClicked").To(vm => vm.ClickSearchCommand);
            set.Bind(View.PhotosTableViewSource).For(v=>v.SelectionChangedCommand).To(vm => vm.ClickItemCommand);
            set.Bind(View.IndicatorView).For(v => v.Hidden).To(vm => vm.HiddenLoading);
            set.Apply();

            View.CollectionView.ReloadData();
        }
    }
}