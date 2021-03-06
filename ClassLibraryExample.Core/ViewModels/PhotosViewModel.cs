﻿using System.Collections.Generic;
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

        private IEnumerable<HitModel> _listHits = new List<HitModel>();

        private string _searchMessage;

        private bool _hiddenLoading;

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

        public bool HiddenLoading
        {
            get { return _hiddenLoading; }
            set
            {
                _hiddenLoading = value;
                RaisePropertyChanged(() => HiddenLoading);
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
            HiddenLoading = false;

            ListHits = await RequestToApiAsync(requestMessage);

            HiddenLoading = true;
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
