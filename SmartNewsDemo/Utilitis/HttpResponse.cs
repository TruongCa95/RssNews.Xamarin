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
using System.Text.RegularExpressions;

namespace SmartNewsDemo.Utilitis
{
    public class HttpResponse : BaseViewModel
    {

        public static List<NewsArticles> listresult { get; set; }

        /// <summary>
        /// check connect internet
        /// </summary>
        public static bool CheckNetwork()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.DisplayAlert("No Internet Connection", "Please connect to Internet", "OK");
                });
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
                    Uri ourUri = new Uri(url);
                    Task.Delay(1000);
                    //Create a WebRequest
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    // Set credentials to use for this request
                    request.Credentials = CredentialCache.DefaultCredentials;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    // Use "ResponseUri" property to get the actual Uri from where the response was attained.
                    if (ourUri.Equals(response.ResponseUri))
                    {
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
                                    var pattern = @"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)";
                                    var img = element.Element(XName.Get("description")).Value;
                                    if (Regex.IsMatch(img, pattern))
                                    {
                                        foreach (Match m in Regex.Matches(img, pattern))
                                        {
                                            result.ThumbnailUrl = m.Value;
                                        }
                                    }
                                    else
                                    {
                                        result.ThumbnailUrl = "https://lh3.googleusercontent.com/qJ2JpLVLV7rbRuEUgNi8cwmOjZhBDC_Ka1pBPpyIxzr6Zs6A_fTLbN-ksIWFW_OddAbfnWniwlT_3vyzRFWytmmclkvsbTTcpeM5MUS1twYDxwryXILcySfA5Vl6Rr6SO8Ixqu6u=w2400";
                                    }
                                }
                                return result;
                            }).ToList();
                            listresult = articles;
                        }
                    }
                    else
                    {
                        throw  new Exception();
                    }    
                }
            }
            catch (Exception)
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.DisplayAlert("Server Error", "Not Response", "OK");
                });
                return;
            }
        }
    }
}
