using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    [Table("actor")]
    public class Actor
    {
        [Column("actor_id")]
        public int ActorId { get; set; }
        
        [Column("first_name")]
        public string FirstName { get; set; }
        
        [Column("last_name")]
        public string LastName { get; set; }
        
        [Column("last_update")]
        public DateTime LastUpdate { get; set; }
    }
}