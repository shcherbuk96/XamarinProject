using ClassLibraryExample.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;

namespace Blank.Views
{
    class DescriptionViewController : MvxViewController<DescriptionViewModel>
    {
        public new DescriptionView View
        {
            get => (DescriptionView)base.View;
            set => base.View = value;
        }

        public override void ViewDidLoad()
        {
            View = new DescriptionView();

            base.ViewDidLoad();

            var set = this.CreateBindingSet<DescriptionViewController, DescriptionViewModel>();
            set.Bind(View.PhotoImageView).For(v => v.Image).To(vm => vm.HitModel.LargeImageURL).WithConversion("ImageConverterStingToImage");
            set.Bind(View.DescriptionLabel).For(v => v.Text).To(vm => vm.HitModel.Comments);
            set.Apply();
        }
    }
}