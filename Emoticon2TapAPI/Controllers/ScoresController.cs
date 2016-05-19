using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Emoticon2TapAPI.Models;
using System.Web.Http.Routing;
namespace Emoticon2TapAPI.Controllers
{
    public class ScoresController : ApiController
    {
        public static readonly Dictionary<int, Score> Scores = new Dictionary<int, Score>();
        public static int nextId = 0;

        public ScoresController()
        {
            Scores.Add(++nextId, new Score(nextId, 1 ,"Player"));
        }

        //GET api/Scores
        public IEnumerable<Score> Get()
        {
            return Scores.Values;
        }


        //Get api/Scores?player=value
        public IEnumerable<Score> Get(string player)
        {
            return Scores.Values.Where(s => s.Player == player);
        }

        //POST api/Scores
        public HttpResponseMessage Post([FromBody] Score score)
        {
            score.Id = ++nextId;
            Scores.Add(score.Id, score);
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
            Scores.Remove(id);
        }
    }
}
