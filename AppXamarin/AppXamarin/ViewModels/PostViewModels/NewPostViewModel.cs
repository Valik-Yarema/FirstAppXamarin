using Xamarin.Forms;
using System.ComponentModel;
using AppXamarin.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using AutoMapper;

namespace AppXamarin.ViewModels.PostViewModels
{
    public class NewPostViewModel : BaseViewModel
    {

        private readonly IMapper _mapper;
        private NewPost newPost;
        private bool isLiked;
        private bool isBookmark;
        public List<PostImgViewModel> Images { get; set; }
        

        public NewPostViewModel()
        {
            newPost = new NewPost();
            //_mapper = mapper;
        }




        public bool IsLiked
        {
            get { return isLiked; }
            set
            {
                SetValue(ref isLiked, value);
                OnPropertyChanged(nameof(LikeS));
            }
        }
        public bool IsBookmark
        {
            get { return isBookmark; }
            set
            {
                SetValue(ref isBookmark, value);
                OnPropertyChanged(nameof(Bookmark));
            }
        }
        public string LikeS
        {
            get
            {
                if (isLiked)
                {
                    return "icons8LoveRed48.png";
                }
                else
                {
                    return "icons8Love48.png";
                }
            }
            
        }
        public string Bookmark
        {
            get
            {
                if (IsBookmark)
                {
                    return "icons8BookmarkFilled50.png";
                }
                else {
                    return "icons8Bookmark50.png";
               }
            }
        }

        

        public int Id
        {
            get { return newPost.Id; }
            set
            {
                if (newPost.Id!= value)
                {
                    newPost.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string AuthorName
        {
            get { return newPost.AuthorName; }
            set
            {
                if (newPost.AuthorName != value)
                {
                    newPost.AuthorName = value;
                    OnPropertyChanged("AuthorName");
                }
            }
        }

        public string NewsText
        {
            get { return newPost.NewsText; }
            set
            {
                if (newPost.AuthorName != value)
                {
                    newPost.NewsText = value;
                    OnPropertyChanged("NewsText");
                }
            }
        }

        public int Like
        {
            get { return newPost.Like; }
            set
            {
                if (newPost.Like != value)
                {
                    newPost.Like = value;
                    OnPropertyChanged("Like");
                }
            }
        }
        public List<PostImgViewModel> PostSource
        {
            get { 
                return _mapper.Map<ICollection<string>, List<PostImgViewModel>>(newPost.Images);
            }
            set
            {
                if (newPost.Images != value)
                {
                    newPost.Images = _mapper.Map<List<PostImgViewModel>,ICollection<string>>(value);
                    OnPropertyChanged("Images");
                }
            }
        }


    }
}
