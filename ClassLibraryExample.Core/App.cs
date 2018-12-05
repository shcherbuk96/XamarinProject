using ClassLibraryExample.Core.Service;
using ClassLibraryExample.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace ClassLibraryExample.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterType<ILoadData, Data>();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
