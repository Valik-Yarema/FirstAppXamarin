
namespace AppXamarin.ViewModels.PostViewModels
{
    public class PostImgViewModel: BaseViewModel
    {
        public string SourceImg { get; set; }

        private string position;
        public string Position
        {
            get { return position; }
            set{
                SetValue(ref position, value);
                OnPropertyChanged(nameof(Position));
            }
        }
    }
}
