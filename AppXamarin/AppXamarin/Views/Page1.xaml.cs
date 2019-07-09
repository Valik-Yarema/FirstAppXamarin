using AppXamarin.Models.DB;
using AppXamarin.ViewModels.PostViewModels;
using AppXamarin.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        public List<NewPostViewModel> viewModel { get; set; }
        Image img = new Image();

        int clickedCount = 0;
		public Page1 ()
        {
            InitializeComponent ();


            CameraTop.Source = ImageSource.FromFile("icons8Camera48.png");
            MessageTop.Source = ImageSource.FromFile("icons8Telegram64.png");
            InstagramText.Source = ImageSource.FromFile("InstagramText.png");
            HomeEnd.Source = ImageSource.FromFile("icons8Home48.png");
            SearchEnd.Source = ImageSource.FromFile("icons8Search48.png");
            AddNewPost.Source = ImageSource.FromFile("icons8AddNew50.png");
            LikeEnd.Source = ImageSource.FromFile("icons8Love48.png");
            Person.Source = ImageSource.FromFile("icons8Person64.png");

            PostsContent.BindingContext = new List<NewPostViewModel>() {new NewPostViewModel()
            {
                AuthorName = "I am author",
                Id = 1,
                Like=0,
                NewsText="assf gfdhd dhfghf hg gfjgfj hj hjhhfj hff gh.",
                PostSource=ImageSource.FromFile("icons8Instagram48.png")
                  
                }};
            ImageNews.BindingContext = new List<ImageSource>() { "icons8Instagram48.png" };

            AddNewPost.Clicked += async (o, e) =>
            {
                if (CrossMedia.Current.IsPickPhotoSupported)
                {
                    MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                    img.Source = ImageSource.FromFile(photo.Path);
                }
            };

            CameraTop.Clicked += async (o, e) =>
             {
                 if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
                 {
                     MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                     {
                         SaveToAlbum = true,
                         Directory = "Sample",
                         Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg"
                     });

                     if (file == null)
                         return;

                     img.Source = ImageSource.FromFile(file.Path);
                 }
             };
            IconInstagram.Tapped += async (o, e) =>
            {
                if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
                {
                    MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        Directory = "Sample",
                        Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg"
                    });

                    if (file == null)
                        return;

                    img.Source = ImageSource.FromFile(file.Path);
                }
            };



        }

        public void ButtonClick(object sender, EventArgs e)
        {
          
            label1.Text = "b:"+ ++clickedCount;
        }
        public void LikeClick(object sender,EventArgs e)
        {
            
        }
        
        public void GetPhotoAsync(object sender, EventArgs e)
        {

            
                if (CrossMedia.Current.IsPickPhotoSupported)
                {
                    MediaFile photo =  CrossMedia.Current.PickPhotoAsync().Result;
                    img.Source = ImageSource.FromFile(photo.Path);
                }
            

        }
        private async void BackButtonClick(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private async void ToProfilePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }
    }
}