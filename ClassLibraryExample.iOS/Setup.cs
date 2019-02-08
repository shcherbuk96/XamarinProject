using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Binding;
using Blank.Views;
using ClassLibraryExample.Core;
using Foundation;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace Blank
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterPropertyInfoBindingFactory(
                typeof(SearchBarBinding),
                typeof(PhotosView), "MyProperty");
        }
    }
}