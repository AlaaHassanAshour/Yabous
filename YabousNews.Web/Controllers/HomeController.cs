
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YabousNews.Data;
using YabousNews.Data.Models;
using YabousNews.Web.Models;
using YabousNews.Web.ViewModels;
using Tweetinvi;
using Tweetinvi.Models;
using Newtonsoft.Json.Linq;

namespace YabousNews.Web.Controllers
{
    public class HomeController : BaseController
    {
        private static string APIKey = "2KjkJoxmYXDYoI7dG2WHP4KzK";
        private static string APIscret = "N1zQbTKdaBpIytaAlTVONpf8NkRQlr3Eor6ZXqOIIj0q7ZZsZ7";
        private static string APIToken = "1479770302229979146-sJnVlzz4xAcuANmvB9Qj8OjJDj733q";
        private static string APITokenScret = "giHuaBK9aObzsznCbgUg7dM2octjTDTObV5H1gUPg86KW";
        public string OAuthConsumerKey { get; private set; }
        public string OAuthConsumerSecret { get; private set; }

        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper,
   INotyfService notyf) : base(userManager, context, mapper, notyf)
        {
        }
        public async Task< IActionResult> Index()
        {

            //var userClient = new TwitterClient(APIKey, APIscret, APIToken, APITokenScret);
            //var user = await userClient.Users.GetAuthenticatedUserAsync();
            JObject jsonTweet;
            using (var client = new HttpClient())
            {
                var url = "https://api.twitter.com/2/users/1479770302229979146/tweets";
                var accessToken = "AAAAAAAAAAAAAAAAAAAAAJKOXwEAAAAA95vrbnOvLZncvrM%2B%2FyraugZwna0%3DjB2h3V7XdB2PGGQBELZG17YVsFz1khh0olXKAFKACuJBQ0doT6";

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var response = await client.GetStringAsync(url);
                // Parse JSON response.
                jsonTweet = JObject.Parse(response);
                ViewBag.tweet = jsonTweet;

            }


            IndexVM indexViweModel = new IndexVM()
            {
                NewsCategory =await _context.NewsCategory.Where(x => x.IsDelete.Equals(false)).OrderByDescending(x => x.Id).ToListAsync(),
                News= await _context.News.Include(x=>x.NewsCategory).Where(x => x.IsDelete.Equals(false)).OrderByDescending(x=>x.Id).ToListAsync(),
                GalleryImages =await _context.GalleryImages.Include(x=>x.Gallery).OrderByDescending(x => x.Id).ToListAsync(),
                Videos =await _context.Videos.OrderByDescending(x => x.Id).ToListAsync(),
                Contact =await _context.Contact.Where(x => x.IsDelete.Equals(false)).OrderByDescending(x => x.Id).ToListAsync(),
                Attachment = await _context.Attachment.Where(x => x.IsDelete.Equals(false)).OrderByDescending(x => x.Id).ToListAsync(),
                Ads = await _context.Ads.OrderByDescending(x => x.Id).Where(x => x.UpDown != 0).ToListAsync()

            };
            return View(indexViweModel);
        }
        public IActionResult Contactus()
        {
            var contactus = _context.ContactUs.OrderByDescending(x => x.Id).ToList();

            return View(contactus);

        }
        /*
        public ActionResult Tweets(int tweets, string username)
        {
            var twitter =new Twitter();

            var userTweets = twitter.GetTweets("chrishall9521", 10).Result.ToList();

            this.ViewBag.Tweets = userTweets;

            return View();
        }

        public async Task<IEnumerable<string>> GetTweets(string userName, int count)
        {
            var accessToken = await GetAccessToken();
            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?count={0}&screen_name={1}&trim_user=1&exclude_replies=1", count, userName));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
            var serializer = new JavaScriptSerializer();
            dynamic json = serializer.Deserialize<object>(await responseUserTimeLine.Content.ReadAsStringAsync());
            var enumerableTwitts = (json as IEnumerable<dynamic>);

            if (enumerableTwitts == null)
            {
                return null;
            }

            return enumerableTwitts.Select(t => (string)(t["text"].ToString()));
        }
     
    public async Task<string> GetAccessToken()
    {
        var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token ");
        var customerInfo = Convert.ToBase64String(new UTF8Encoding().GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));
        request.Headers.Add("Authorization", "Basic " + customerInfo);
        request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

        var response = await httpClient.SendAsync(request).ConfigureAwait(false);

        string json = await response.Content.ReadAsStringAsync();
        var serializer = new JavaScriptSerializer();
        dynamic item = serializer.Deserialize<object>(json);
        return item["access_token"];
    }*/
    }
}
