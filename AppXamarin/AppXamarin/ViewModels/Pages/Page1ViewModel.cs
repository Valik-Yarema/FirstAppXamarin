using AppXamarin.ViewModels.PostViewModels;
using AppXamarin.Views;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarin.ViewModels.Pages
{
   public class Page1ViewModel:BaseViewModel
   {
        public NewPostsViewModel Posts { get; private set; }
        public ICommand CameraOpenCommand { get; private set; }
        public ICommand CreatePageCommand { get; private set; }
        public ICommand HomePageCommand { get; private set; }
       

        public Page1ViewModel()
        {
            CameraOpenCommand = new Command(CameraOpen);
            HomePageCommand = new Command(HomePage);
            CreatePageCommand = new Command<string>(cp => CreatePage(cp));
            Posts = new NewPostsViewModel();
        }
        
        private async void CameraOpen()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("No Camera :(", "No camera available", "OK O:)");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = $"test{ DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss") }.jpg"
                });

                if (file == null)
                {
                    return;
                }

                await Application.Current.MainPage.DisplayAlert("File Path", file.Path, "OK");
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong!", "OK");
            }
        }
     
        private async void CreatePage(string title)
        {
            Page page = new CreatePostPage() { Title = title };
            await PushAsync(page);
        }
       
        private async void HomePage()
        {
            Page page = new Page1();
            await PushAsync(page);
        }

        private async void ProfilePage()
        {
            Page page = new Profile();
            await PushAsync(page);
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}

