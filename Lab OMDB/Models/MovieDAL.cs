﻿using Newtonsoft.Json;
using System.Net;

namespace Lab_OMDB.Models
{
    public class MovieDAL
    {
        public MovieModel GetMovie(string title)
        {
            string url = $"http://www.omdbapi.com/?apikey=6047e6f7&t={title}";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);

            return result;
        }        
    }
}
