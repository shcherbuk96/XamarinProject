using ClassLibraryExample.Core.Pojo;
using ClassLibraryExample.Core.Service;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace ClassLibraryExample.Core
{
    public class MainViewModel : MvxViewModel
    {
        private readonly ILoadData _loadData;

        private ObservableCollection<Hit> _lists;

        private string _searchMessage;

        private readonly IMvxNavigationService _navigationService;

    
        private MvxCommand<MainViewModel> _clickCommand;
        public MvxCommand<MainViewModel> ClickCommand => _clickCommand = _clickCommand ?? new MvxCommand<MainViewModel>(OnHitClickCommand);

        public MainViewModel(ILoadData loadData, IMvxNavigationService navigationService)
        {
            _loadData = loadData;
            _navigationService = navigationService;
        }

        public ObservableCollection<Hit> Lists
        {
            get { return _lists; }
            set
            {
                _lists = value;
                RaisePropertyChanged(() => Lists);
            }
        }

        private void OnHitClickCommand(MainViewModel vm)
        {
            ShowDescriptionViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<DescriptionViewModel>());
        }

        public IMvxAsyncCommand ShowDescriptionViewModelCommand { get; private set; }

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
            Lists = new ObservableCollection<Hit>(await _loadData.GetDataAsync(UrlApi("cats")));
        }

        public async void Searchdata(string message)
        {
            Lists = new ObservableCollection<Hit>(await _loadData.GetDataAsync(UrlApi(message)));
        }

        public static string UrlApi(string str) => $"https://pixabay.com/api/?key=10828462-e34b53653a419d947bfaba5d3&q={str}&image_type=photo/";
    }
}
