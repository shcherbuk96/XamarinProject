using ClassLibraryExample.Core.Pojo;
using MvvmCross.ViewModels;

namespace ClassLibraryExample.Core.ViewModels
{
    public class DescriptionViewModel : MvxViewModel<HitModel>
    {
        private HitModel _hitModel;

        private string _user;

        private string _photoUrl;

        private string _tags;

        private string _likes;

        private string _comments;

        private string _webUrl;

        public override void Prepare(HitModel parameter)
        {
            _hitModel = parameter;

            User = _hitModel.User;
            PhotoUrl = _hitModel.LargeImageURL;
            Tags = _hitModel.Tags;
            Likes = _hitModel.Likes.ToString();
            Comments = _hitModel.Comments.ToString();
            WebUrl = _hitModel.PageURL;
        }

        public string User
        {
            get { return _user; }
            set
            {
                _user = value; 
                RaisePropertyChanged(() => User);

            }
        }

        public string PhotoUrl
        {
            get { return _photoUrl; }
            set
            {
                _photoUrl = value;
                RaisePropertyChanged(() => PhotoUrl);
            }
        }

        public string Tags
        {
            get { return _tags; }
            set
            {
                _tags = value;
                RaisePropertyChanged(() => Tags);
            }
        }

        public string Likes
        {
            get { return _likes; }
            set
            {
                _likes = value;
                RaisePropertyChanged(() => Likes);
            }
        }

        public string Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                RaisePropertyChanged(() => Comments);
            }
        }

        public string WebUrl
        {
            get { return _webUrl; }
            set
            {
                _webUrl = value;
                RaisePropertyChanged(() => WebUrl);
            }
        }

        public override void ViewCreated()
        {
            base.ViewCreated();

            SetHitModel();
        }

        private void SetHitModel()
        {

        }
    }
}
