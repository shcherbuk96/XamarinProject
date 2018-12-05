using System.Collections.ObjectModel;
using ClassLibraryExample.Core.Pojo;
using ClassLibraryExample.Core.Service;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace ClassLibraryExample.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly ILoadData _loadData;

        private ObservableCollection<HitModel> _lists;

        private string _searchMessage;

        private readonly IMvxNavigationService _navigationService;


        public MainViewModel(ILoadData loadData, IMvxNavigationService navigationService)
        {
            _loadData = loadData;
            _navigationService = navigationService;
        }

        private MvxCommand<HitModel> _clickCommand;
        public MvxCommand<HitModel> ClickCommand => _clickCommand =
            _clickCommand ?? new MvxCommand<HitModel>(OnClickCommand);

        private async void OnClickCommand(HitModel obj)
        {
            await _navigationService.Navigate<DescriptionViewModel,HitModel>(obj);
        }

        private MvxCommand _myAwesomeCommand;
        public IMvxCommand MyAwesomeCommand
        {
            get
            {
                _myAwesomeCommand= _myAwesomeCommand ?? new MvxCommand(StartNextActivity);
                return _myAwesomeCommand;
            }
        }

        private async void StartNextActivity()
        {
            await _navigationService.Navigate<DescriptionViewModel>();
        }


        public ObservableCollection<HitModel> Lists
        {
            get { return _lists; }
            set
            {
                _lists = value;
                RaisePropertyChanged(() => Lists);
            }
        }

        public string SearchMessage
        {
            get { return _searchMessage; }
            set
            {
                _searchMessage = value;
                RaisePropertyChanged(() => SearchMessage);

                Searchdata(_searchMessage);
            }
        }

        public override void ViewCreated()
        {
            base.ViewCreated();

            DefaultData();
        }

        public async void DefaultData()
        {
            Lists = new ObservableCollection<HitModel>(await _loadData.GetDataAsync(UrlApi("cats")));
        }

        public async void Searchdata(string message)
        {
            Lists = new ObservableCollection<HitModel>(await _loadData.GetDataAsync(UrlApi(message)));
        }

        public static string UrlApi(string str) => $"https://pixabay.com/api/?key=10828462-e34b53653a419d947bfaba5d3&q={str}&image_type=photo/";
    }
}
