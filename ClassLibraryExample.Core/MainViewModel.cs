using ClassLibraryExample.Core.Pojo;
using ClassLibraryExample.Core.Service;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ClassLibraryExample.Core
{
    public class MainViewModel : MvxViewModel
    {
        readonly ILoadData loadData;

        private ObservableCollection<Hit> _lists;

        private string _search_message;

        private readonly IMvxNavigationService _navigationService;

    
        private MvxCommand<MainViewModel> _clickCommand;
        public MvxCommand<MainViewModel> ClickCommand => _clickCommand = _clickCommand ?? new MvxCommand<MainViewModel>(OnHitClickCommand);

        public MainViewModel(ILoadData loadData, IMvxNavigationService navigationService)
        {
            this.loadData = loadData;
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
            get { return _search_message; }
            set
            {
                _search_message = value;
                RaisePropertyChanged(() => SearchMessage);

                Searchdata(_search_message);
            }
        }

        public async override void ViewCreated()
        {
            base.ViewCreated();

            DefaultData();
        }

        public async void DefaultData()
        {
            Lists = new ObservableCollection<Hit>(await loadData.GetDataAsync(UrlAPI("cats")));
        }

        public async void Searchdata(string message)
        {
            Lists = new ObservableCollection<Hit>(await loadData.GetDataAsync(UrlAPI(message)));
        }

        public static string UrlAPI(string str) => $"https://pixabay.com/api/?key=10828462-e34b53653a419d947bfaba5d3&q={str}&image_type=photo/";
    }
}
