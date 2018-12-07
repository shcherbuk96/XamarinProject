using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ClassLibraryExample.Core.Pojo;
using ClassLibraryExample.Core.Service;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace ClassLibraryExample.Core.ViewModels
{
    public class PhotosViewModel : MvxViewModel
    {
        private readonly ILoadDataService _loadDataService;

        private ObservableCollection<HitModel> _lists;

        private string _searchMessage;

        private readonly IMvxNavigationService _navigationService;


        public PhotosViewModel(ILoadDataService loadDataService, IMvxNavigationService navigationService)
        {
            _loadDataService = loadDataService;
            _navigationService = navigationService;
        }

        private MvxCommand<HitModel> _clickItemCommand;
        public MvxCommand<HitModel> ClickItemCommand => _clickItemCommand =
            _clickItemCommand ?? new MvxCommand<HitModel>(OnClickItemCommand);

        private async void OnClickItemCommand(HitModel obj)
        {
            await _navigationService.Navigate<DescriptionViewModel,HitModel>(obj);
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
                
                GetResponceFromSearchAsync();
            }
        }

        public async void GetResponceFromSearchAsync()
        {
            Lists = await SearchRequestToApiAsync(_searchMessage);
        }


        public override async void ViewCreated()
        {
            base.ViewCreated();

            Lists = await DefaultRequestToApiAsync();
        }

        public async Task<ObservableCollection<HitModel>> DefaultRequestToApiAsync()
        {
            return new ObservableCollection<HitModel>(await _loadDataService.GetDataAsync(UrlApi(Constants.DefaultRequestToApi)));
        }

        public async Task<ObservableCollection<HitModel>> SearchRequestToApiAsync(string message)
        {
            return new ObservableCollection<HitModel>(await _loadDataService.GetDataAsync(UrlApi(message)));
        }

        public static string UrlApi(string message) => $"https://pixabay.com/api/?key=10828462-e34b53653a419d947bfaba5d3&q={message}&image_type=photo/";
    }
}
