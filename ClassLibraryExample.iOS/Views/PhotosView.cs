using Cirrious.FluentLayouts.Touch;
using Blank.PhotosTableView;
using CoreGraphics;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Blank.Views
{
   public class PhotosView : MvxView
    {
        public UICollectionView CollectionView { get; set; }
        public PhotosTableViewSource PhotosTableViewSource { get; set; }
        public UIActivityIndicatorView IndicatorView { get; set; }
        public UISearchBar SearchBar { get; set; }

        public PhotosView()
        {
            Initialize();
        }

        private void Initialize()
        { 
            SetupSubviews();
            SetupSubviewsConstraints();
            SetupLayout();
            SetupLayoutConstraints();
        }

        protected virtual void SetupSubviews()
        {
            var layout = new UICollectionViewFlowLayout
            {
                ItemSize = new CGSize(UIScreen.MainScreen.Bounds.Width, 250),
                ScrollDirection = UICollectionViewScrollDirection.Vertical,
                MinimumInteritemSpacing = 0,
                MinimumLineSpacing = 0
            };
            IndicatorView=new UIActivityIndicatorView();
            SearchBar = new UISearchBar
            {
                SearchBarStyle = UISearchBarStyle.Minimal
            };
            CollectionView = new UICollectionView(new CGRect(0, 0, 0, 0), layout);
            CollectionView.AllowsSelection = true;
            CollectionView.BackgroundColor = UIColor.White;
            PhotosTableViewSource = new PhotosTableViewSource(CollectionView);
            CollectionView.Source = PhotosTableViewSource;
        }


        protected virtual void SetupSubviewsConstraints()
        {
        }

        protected virtual void SetupLayout()
        {
            AddSubviews(CollectionView,IndicatorView, SearchBar);
        }

        protected virtual void SetupLayoutConstraints()
        {
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            this.AddConstraints(
                SearchBar.AtTopOfSafeArea(this),
                SearchBar.AtLeftOf(this),
                SearchBar.AtRightOf(this),
                SearchBar.Above(CollectionView));

            this.AddConstraints(
                IndicatorView.WithSameCenterX(this),
                IndicatorView.WithSameCenterY(this));

            this.AddConstraints(
                //CollectionView.Above(SearchBar),
                CollectionView.AtBottomOfSafeArea(this),
                CollectionView.AtLeftOf(this),
                CollectionView.AtRightOf(this));
        }
    }
}