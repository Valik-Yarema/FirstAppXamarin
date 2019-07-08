using Xamarin.Forms;
using System.ComponentModel;
using AppXamarin.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace AppXamarin.ViewModels.PostViewModels
{
    public class NewPostViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private NewPost newPost;
        public ICommand Increase { get; }

        public NewPostViewModel()
        {
            newPost = new NewPost();
            Increase = new Command(IncreaseLike);
        }

        public void IncreaseLike()
        {
            if (newPost != null)
            { Like++; }
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
        public ImageSource PostSource
        {
            get { return newPost.PostSource; }
            set
            {
                if (newPost.PostSource != value)
                {
                    newPost.PostSource = value;
                    OnPropertyChanged("ImageSourse");
                }
            }
        }


        //public ICollection<Image> Images
        //{
        //    get { return newPost.Images; }
        //    set
        //    {
        //        if (newPost.Images != value)
        //        {
        //            newPost.Images = value;
        //            OnPropertyChanged("Images");
        //        }
        //    }
        //}


        //public List<Image> Images
        //{
        //    get {
        //      var imgs=  new List<Image>();
        //        foreach (var imageSource in newPost.Images)
        //        {
        //            imgs.Add(new Image() { Source = imageSource });
        //        }

        //        return imgs; }
        //    set
        //    {
        //        if (newPost.Images != value)
        //        {
        //            var sourse = new List<FileImageSource>();
        //            foreach (var image in value)
        //            {
        //                sourse.Add(image.Source.AutomationId);
        //            }
        //            newPost.Images = ;
        //            OnPropertyChanged("NewsText");
        //        }
        //    }
        //}

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
