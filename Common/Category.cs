using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    [Table("category")]
    public class Category
    {
        [Column("category_id")]
        public byte CategoryId { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("last_update")]
        public DateTime LastUpdate { get; set; }
    }
}