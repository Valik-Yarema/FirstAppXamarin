using AppXamarin.ViewModels.Pages;
using AppXamarin.ViewModels.PostViewModels;
using AppXamarin.Views;
using CarouselView;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.ComponentModel;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarouselView.FormsPlugin.Abstractions;
using System.Linq;

namespace AppXamarin
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class Page1 : ContentPage
	{
		public Page1 ()
        {
            InitializeComponent ();
            ViewContext = new Page1ViewModel();

            CameraTop.Source = ImageSource.FromFile("icons8Camera48.png");
            MessageTop.Source = ImageSource.FromFile("icons8Telegram64.png");
            InstagramText.Source = ImageSource.FromFile("InstagramText.png");
            HomeEnd.Source = ImageSource.FromFile("icons8Home48.png");
            SearchEnd.Source = ImageSource.FromFile("icons8Search48.png");
            AddNewPost.Source = ImageSource.FromFile("icons8AddNew50.png");
            LikeEnd.Source = ImageSource.FromFile("icons8Love48.png");
            Person.Source = ImageSource.FromFile("icons8Person64.png");
        }

        public Page1ViewModel ViewContext
        {
            get { return BindingContext as Page1ViewModel; }
            set { BindingContext = value; }
        }
        private void CreatePage(object sender, System.EventArgs e)
        {
            ViewContext.CreatePageCommand.Execute(((Image)sender).StyleId);
        }
        private void CameraClick(object sender, System.EventArgs e)
        {
            ViewContext.CameraOpenCommand.Execute(sender);
        }
        private void SettingMenu(object sender, System.EventArgs e)
        {
            ViewContext.Posts.OpenSettingCommand.Execute(sender);
        }

              
        public void LikeClick(object sender, EventArgs e)
        {
            ViewContext.Posts.AddLikePostCommand.Execute((NewPostViewModel)((Image)sender).BindingContext);
        }

        private void AddBookmark(object sender, System.EventArgs e)
        {
            ViewContext.Posts.AddBookmarkPostCommand.Execute((NewPostViewModel)((Image)sender).BindingContext);
        }
        private void SharePost(object sender, System.EventArgs e)
        {
            ViewContext.Posts.SharePostCommand.Execute(sender);
        }
        private void ViewComents(object sender, System.EventArgs e)
        {
            ViewContext.CreatePageCommand.Execute(((Label)sender).StyleId);
        }

        private void ChangePosition(object sender, PositionSelectedEventArgs e)
        {
            var post = (NewPostViewModel)((CarouselViewControl)sender).BindingContext;
            var position = ((CarouselViewControl)sender).Position;
            post.Images[position].Position = $"{position + 1}/{post.Images.Count}";
        }

        private void HomePage(object sender, System.EventArgs e)
        {
            ViewContext.HomePageCommand.Execute(sender);
        }

        public void GetPhotoAsync(object sender, EventArgs e)
        {
                if (CrossMedia.Current.IsPickPhotoSupported)
                {
                    MediaFile photo =  CrossMedia.Current.PickPhotoAsync().Result;
                 
                }
        }

        private async void ToProfilePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }
        

    }
}