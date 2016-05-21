using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Emoticon2TapAPI.Models
{
    public class Score
    {
        // prop
        [Key]
        public int Id { get; set; }
        public string Player { get; set; }

        public int score  { get; set; }

        public string datetime { get; set; }
        public Score() { }
        public Score( int score, string player, string datetime) {
            //this.Id = Id;
            this.Player = player;
            this.score = score;
            this.datetime = datetime;
        }
    }
}