using ClassLibraryExample.Core.Pojo;
using MvvmCross.ViewModels;

namespace ClassLibraryExample.Core.ViewModels
{
    public class DescriptionViewModel : MvxViewModel<HitModel>
    {
        private HitModel _hitModel;

        public HitModel HitModel
        {
            get { return _hitModel; }
            set
            {
                _hitModel = value;
                RaisePropertyChanged(() => HitModel);
            }
        }

        public override void Prepare(HitModel parameter)
        {
            _hitModel = parameter;
        }
        
    }
}
