using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarin.ViewModels.PostViewModels
{
    public class NewPostsViewModel : BaseViewModel
    {
        public ObservableCollection<NewPostViewModel> NewPosts { get; private set; }
        public ICommand OpenSettingCommand { get; private set; }
        public ICommand AddLikePostCommand { get; private set; }
        public ICommand AddBookmarkPostCommand { get; private set; }
        public ICommand SharePostCommand { get; private set; }

        public NewPostsViewModel()
        {
            NewPosts = new ObservableCollection<NewPostViewModel>();
            OpenSettingCommand = new Command(OpenSetting);
            AddLikePostCommand = new Command<NewPostViewModel>(post => AddLikePost(post));
            AddBookmarkPostCommand = new Command<NewPostViewModel>(post => AddBookmarkPost(post));
            SharePostCommand = new Command<NewPostViewModel>(post => SharePost(post));
            Seed();
        }

        private async void OpenSetting()
        {
            await Application.Current.MainPage.DisplayActionSheet("","Пожаловаться", "Отменить подписку на хэштег",
                "Копировать ссылку", "Поделиться...", "Не показывать для этого хэштега","Отменa");
        }

        private void AddLikePost(NewPostViewModel post)
        {
            if (post == null)
                return;
            if (post.IsLiked == false)
            {
                post.IsLiked = true;
                post.Like += 1;
            }
            else
            {
                post.IsLiked = false;
                post.Like -= 1;
            }
        }

        private void AddBookmarkPost(NewPostViewModel post)
        {

            if (post.IsBookmark == false)
            {
                post.IsBookmark = true;
            }
            else
            {
                post.IsBookmark = false;
            }
        }

        private async void SharePost(NewPostViewModel post)
        {
            //add after posting messages
        }
        private void Seed()
        {
            NewPosts.Add(new NewPostViewModel()
            {
                AuthorName = "BBC",
                Images = new List<PostImgViewModel>() {
                     new PostImgViewModel{SourceImg = "https://ichef.bbci.co.uk/news/660/cpsprodpb/0B57/production/_107830920_hi043441369.jpg" },
                     new PostImgViewModel{SourceImg = "https://ichef.bbci.co.uk/news/624/cpsprodpb/A797/production/_107830924_hi041110960.jpg" },
                },
                Like = 10,
                NewsText = "The biggest and most powerful warship ever built in Britain experienced the leak during sea trials on Tuesday.It was believed to have come from a ruptured pipe which caused some internal damage, the BBC learned.The Royal Navy described it as a minor issue relating to water from an internal system on the £3.1bn ship.On Wednesday a Royal Navy statement said the ship had returned early from sea trials as a precautionary measure with an investigation into the cause underway.It said: At no point was there damage or breach to the hull. The issue was isolated as soon as possible and all water has now been pumped out.The BBC's defence correspondent Jonathan Beale said the leak was more serious than most.He added: A source told the BBC that in some compartments the water was neck high."
            });
            NewPosts.Add(new NewPostViewModel()
            {
                AuthorName = "BBC",
                Images = new List<PostImgViewModel>() {
                    new PostImgViewModel{SourceImg="https://ichef.bbci.co.uk/news/660/cpsprodpb/324C/production/_107367821_976549pkrfhx.jpg"},
                     new PostImgViewModel{SourceImg="https://ichef.bbci.co.uk/news/624/cpsprodpb/A77C/production/_107367824_4a1cb473-b510-4b2b-89c7-73ecfb007beb.jpg"},
                      new PostImgViewModel{SourceImg="https://ichef.bbci.co.uk/news/624/cpsprodpb/8986/production/_107460253_gettyimages-105558196.jpg"},
                      new PostImgViewModel{SourceImg="https://ichef.bbci.co.uk/news/624/cpsprodpb/FEB6/production/_107460256_gettyimages-653163090.jpg"},
                       new PostImgViewModel{SourceImg="https://ichef.bbci.co.uk/news/624/cpsprodpb/15DD5/production/_107475598_976600gettyimages-101581856.jpg"},
                },
                Like = 9,
                NewsText = "Piedmont, in north-west Italy, is celebrated for its fine wine. But when a young Englishman, John Lombe, travelled there in the early 18th Century, he was not going to savour a glass of Barolo. His purpose was industrial espionage.Lombe wished to figure out how the Piedmontese spun strong yarn from silkworm silk. Divulging such secrets was illegal, so Lombe sneaked into a workshop after dark, sketching the spinning machines by candlelight. In 1717, he took those sketches to Derby in the heart of England.Local legend has it that the Italians took a terrible revenge on Lombe,sending a woman to assassinate him.Whatever the truth of that,he died suddenly at the age of 29,just a few years after his Piedmont adventure."
            });

            NewPosts.Add(new NewPostViewModel()
            {
                AuthorName = "BBC",
                Images = new List<PostImgViewModel>() {
                     new PostImgViewModel{SourceImg = "https://e3.365dm.com/18/10/1600x900/skynews-cuadrilla-fracking-site_4451750.jpg?bypass-service-worker&20181013032512" },
                     new PostImgViewModel{SourceImg="https://e3.365dm.com/18/10/1600x900/skynews-vivienne-westwood-cuadrilla_4455743.jpg?bypass-service-worker&20181017134326"},
                },
                Like = 8,
                NewsText = "The controversial process of fracking for shale gas will resume at a site near Blackpool in Lancashire, Cuadrilla has confirmed.The company said it would remobilise hydraulic fracturing equipment in the third quarter of 2019.If added that subject to regulatory approvals the work will be complete by the end of November this year.Cuadrilla repeatedly had to stop operations at the Preston New Road site last year because of minor seismic events.British rules mean fracking must be suspended if activity of magnitude 0.5 or more on the Richter scale is detected - much lower than the threshold in the US."
            });
        }
    }
}
