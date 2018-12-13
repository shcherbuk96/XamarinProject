using System.Collections.Generic;
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

        private readonly IMvxNavigationService _navigationService;

        //private IList<HitModel> _listHits=new List<HitModel>();

        private IEnumerable<HitModel> _listHits = new List<HitModel>();

        private string _searchMessage;

        private int _loading = Constants.Gone;

        private MvxCommand<HitModel> _clickItemCommand;

        private MvxCommand _clickSearchCommand;

        public PhotosViewModel(ILoadDataService loadDataService, IMvxNavigationService navigationService)
        {
            _loadDataService = loadDataService;
            _navigationService = navigationService;
        }

        public IEnumerable<HitModel> ListHits
        {
            get { return _listHits; }
            set
            {
                _listHits = value;
                RaisePropertyChanged(() => ListHits);
            }
        }

        //public IList<HitModel> ListHits
        //{
        //    get { return _listHits; }
        //    set
        //    {
        //        _listHits = value;
        //        RaisePropertyChanged(() => ListHits);
        //    }
        //}

        public int Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                RaisePropertyChanged(() => Loading);
            }
        }

        public string SearchMessage
        {
            get { return _searchMessage; }
            set
            {
                _searchMessage = value;
                RaisePropertyChanged(() => SearchMessage);
            }
        }

        public MvxCommand<HitModel> ClickItemCommand => _clickItemCommand =
            _clickItemCommand ?? new MvxCommand<HitModel>(OnClickItemCommand);

        public MvxCommand ClickSearchCommand => _clickSearchCommand =
            _clickSearchCommand ?? new MvxCommand(async()=>await UpdateListHits(SearchMessage));

        public override async void ViewCreated()
        {
            base.ViewCreated();
            
            await UpdateListHits(Constants.DefaultRequestToApi);
        }

        private async Task UpdateListHits(string requestMessage)
        {
            Loading = Constants.Visible;

            ListHits = await RequestToApiAsync(requestMessage);

            //ListHits = new List<HitModel>(await RequestToApiAsync(requestMessage));
            //foreach (var hit in await RequestToApiAsync(requestMessage))
            //{
            //    ListHits.Add(hit);
            //}

            Loading = Constants.Gone;
        }

        private async Task<IEnumerable<HitModel>> RequestToApiAsync(string requestMessage)
        {
            return await _loadDataService.GetDataAsync(UrlApi(requestMessage));
        }
        
        private static string UrlApi(string message) => $"https://pixabay.com/api/?key=10828462-e34b53653a419d947bfaba5d3&q={message}&image_type=photo/";

        private async void OnClickItemCommand(HitModel obj)
        {
            await _navigationService.Navigate<DescriptionViewModel, HitModel>(obj);
        }
    }
}
