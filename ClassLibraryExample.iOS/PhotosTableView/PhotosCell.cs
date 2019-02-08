using System;
using Cirrious.FluentLayouts.Touch;
using ClassLibraryExample.Core.Pojo;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Blank.PhotosTableView
{
    class PhotosCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("CustomCell");
        private static readonly UINib _nib;
        
        public PhotosCell(IntPtr handle) : base(handle)
        {
            CreateLayout();
            InitializeBindings();
        }

        public UIStackView StackView { get; set; }
        public UILabel UserLabel { get; set; }
        public UILabel TagsLabel { get; set; }
        public UIImageView PhotoImageView { get; set; }

        public string User
        {
            get => UserLabel.Text;
            set => UserLabel.Text = value;
        }

        public string Tags
        {
            get => TagsLabel.Text;
            set => TagsLabel.Text = value;
        }

        public UIImage Photo
        {
            get => PhotoImageView.Image;
            set => PhotoImageView.Image = value;
        }

        private void InitializeBindings()
        {
            this.CreateBinding().For(cell => cell.User).To((HitModel model) => model.User).Apply();
            this.CreateBinding().For(cell => cell.Tags).To((HitModel model) => model.Tags).Apply();
            this.CreateBinding().For(cell=>cell.Photo).To((HitModel model) => model.LargeImageURL).WithConversion("ImageConverterStingToImage").Apply();
        }

        private void CreateLayout()
        {

            StackView = new UIStackView
            {
                Alignment = UIStackViewAlignment.Fill,
                Distribution = UIStackViewDistribution.FillEqually,
                
            };
            UserLabel = new UILabel
            {
                Lines = 0,
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.Black,
            };

            TagsLabel = new UILabel
            {
                Lines = 0,
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.Black
            };

            PhotoImageView = new UIImageView
            {
                ContentMode = UIViewContentMode.ScaleAspectFill,
                ClipsToBounds = true
            };

            AddSubviews(PhotoImageView,StackView);

            StackView.AddArrangedSubview(UserLabel);
            StackView.AddArrangedSubview(TagsLabel);

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                StackView.AtLeftOf(this, 8),
                StackView.AtRightOf(this, 8),
                StackView.AtBottomOf(this, 8));

            this.AddConstraints(
                PhotoImageView.AtTopOf(this, 8),
                PhotoImageView.AtLeftOf(this, 8),
                PhotoImageView.AtRightOf(this, 8),
                PhotoImageView.Above(StackView, 8));

            TagsLabel.SetContentCompressionResistancePriority(1000, UILayoutConstraintAxis.Vertical);
        }
    }
}