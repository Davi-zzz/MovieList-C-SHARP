using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace MovieList.Utils
{
    public class Utils
    {
        public static List<int> GetEnumValuesFromLabels(List<Enum> values)
        {
            List<int> numericValues = new List<int>();
            Array enumValues = Enum.GetValues(typeof(FavoriteTags));

            foreach (FavoriteTags tag in enumValues)
            {
                numericValues.Add(Convert.ToInt32(tag));
            }

            return numericValues;
        }
        public string APIRequester(string s = "", string page = null, string r = "json", APIOperation apiop = APIOperation.LIST) {
            string json = System.IO.File.ReadAllText(@"C:\Users\davis\source\repos\WebApplication1\WebApplication1\appsettings.json");
            string apiKey = (string)JsonConvert.DeserializeObject<JObject>(json)["apiKey"];
            string apiHost = "moviesdatabase.p.rapidapi.com";
            string url = "";

            switch (apiop)
            {
                case APIOperation.LIST:
                    url = "https://moviesdatabase.p.rapidapi.com/titles";
                    break;

                case APIOperation.SEARCH_BY_TITLE:
                    url = "https://moviesdatabase.p.rapidapi.com/titles/search/title/"+s+"?exact=false";
                    break;

                case APIOperation.SEARCH_BY_ID:
                    url = $"https://moviesdatabase.p.rapidapi.com/titles/{s}";
                    break;

                case APIOperation.PAGINATE:
                    url = $"https://moviesdatabase.p.rapidapi.com{page}";
                    break;

            }

            Console.WriteLine(url);
            WebClient client = new WebClient();
            client.Headers.Add("X-RapidAPI-Key", apiKey);
            client.Headers.Add("X-RapidAPI-Host", apiHost);
            string response = client.DownloadString(url);
            return response;
        }

    }
    public class MovieProperties
    {
        public string id;
        public string title;
        public string description;
        public string imageAddress;
        public int releaseYear;
    }
}