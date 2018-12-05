using ClassLibraryExample.Core.Service;
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
            // if you want to use a custom AppStart, you should replace the previous line with this one:
            // RegisterCustomAppStart<MyCustomAppStart>();
        }
    }
}
