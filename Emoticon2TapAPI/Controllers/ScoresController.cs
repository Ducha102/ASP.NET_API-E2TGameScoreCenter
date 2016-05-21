using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Emoticon2TapAPI.Models;
using System.Web.Http.Routing;
using System.Data;

namespace Emoticon2TapAPI.Controllers
{
    public class ScoresController : ApiController
    {
        // public static readonly Dictionary<int, Score> Scores = new Dictionary<int, Score>();
        List<Score> Scores;
        public static int nextId = 0;

        public ScoresController()
        {
            Scores = DataHelper.SelectAllScore();

        }

        //GET api/Scores
        public IEnumerable<Score> Get()
        {
            return Scores;
        }


        //Get api/Scores?player=value
        public IEnumerable<Score> Get(string player)
        {
            return Scores.Where(s => s.Player == player);
        }

        //POST api/Scores
        public HttpResponseMessage Post([FromBody] Score score)
        {
            score.Id = nextId++;
            DataHelper.InsertScore(score);
            Scores.Add( score);
            var response = Request.CreateResponse<Score>(HttpStatusCode.Created, score);
            string uri = Url.Link("DefaultApi", new { id = score.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }


        //PUT   api/Scores/id
        public void Put(int id, [FromBody] Score score)
        {
            score.Id = id;
            Scores[id] = score;
        }

        //DELETE api/Scores/id
        public void Delete(int id)
        {
            //Scores.Remove(id);
        }
    }
}
