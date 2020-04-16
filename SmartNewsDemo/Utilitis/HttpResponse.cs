using Plugin.Connectivity;
using SmartNewsDemo.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using SmartNewsDemo.View;
using SmartNewsDemo.ViewModel;
using System.Threading;
using System;

namespace SmartNewsDemo.Utilitis
{
    public class HttpResponse : BaseViewModel
    {

        public static ObservableCollection<NewsArticles> listresult { get; set; }

        /// <summary>
        /// check connect internet
        /// </summary>
        public static bool CheckNetwork()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                Application.Current.MainPage.DisplayAlert("No Internet Connection", "Please connect to Internet", "OK");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Convert rss to data
        /// </summary>
        public static void ReponseServer(string url)
        {
            try
            {
                if (url != string.Empty)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    //Create a WebRequest
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    // Set credentials to use for this request
                    request.Credentials = CredentialCache.DefaultCredentials;

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response != null)
                    {
                        // Get XMLRss
                        Stream stream = response.GetResponseStream();

                        // Pipes the stream to a higher level stream reader with the required encoding format.
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        string xml = reader.ReadToEnd();

                        //Parse XML to data
                        XDocument doc = XDocument.Parse(xml);
                        XElement rss = doc.Element(XName.Get("rss"));
                        XElement channel = rss.Element(XName.Get("channel"));

                        //binding data to item
                        List<NewsArticles> articles = channel.Elements(XName.Get("item")).Select((XElement element) =>
                        {
                            var result = new NewsArticles();
                            {
                                result.Title = element.Element(XName.Get("title")).Value;
                                result.Description = element.Element(XName.Get("description")).Value;
                                result.Link = element.Element(XName.Get("link")).Value;
                                result.Updated = element.Element(XName.Get("pubDate")).Value;
                                result.ThumbnailUrl = "";
                            }
                            return result;
                        }).ToList();
                        listresult = new ObservableCollection<NewsArticles>(articles);
                    }
                }
            }
            catch (Exception)
            {
                
                Application.Current.MainPage.DisplayAlert("Server Error", "Not Response", "OK");
                return;
            }
        }
    }
}
