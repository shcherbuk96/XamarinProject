using ClassLibraryExample.Core;
using ClassLibraryExample.Droid.Binding;
using FFImageLoading.Views;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Android.Core;

namespace ClassLibraryExample.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
            registry.RegisterCustomBindingFactory<ImageViewAsync>("ImageAsync", imageViewAsync=> new ImageAsyncBinding(imageViewAsync));
        }
    }
}