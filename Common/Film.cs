using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    [Table("film")]
    public class Film
    {
        [Column("film_id")]
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        [Column("release_year")]
        public string ReleaseYear { get; set; }
        
        [Column("rental_duration")]
        public byte RentalDuration { get; set; }
        
        [Column("rental_rate")]
        public decimal RentalRate { get; set; }
        public short? Length { get; set; }
        
        [Column("replacement_cost")]
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; }
        
        [Column("special_features")]
        public string SpecialFeatures { get; set; }
        
        [Column("last_update")]
        public DateTime LastUpdate { get; set; }

        public ICollection<FilmActor> FilmActors { get; set; }
        public ICollection<FilmCategory> FilmCategories { get; set; }
    }

    [Table("film_actor")]
    public class FilmActor
    {
        [Column("actor_id")]
        public int ActorId { get; set; }
        
        [Column("film_id")]
        public int FilmId { get; set; }
        
        [Column("last_update")]
        public DateTime LastUpdate { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Film Film { get; set; }
    }

    [Table("film_category")]
    public class FilmCategory
    {
        [Column("film_id")]
        public int FilmId { get; set; }
        
        [Column("category_id")]
        public byte CategoryId { get; set; }
        
        [Column("last_update")]
        public DateTime LastUpdate { get; set; }

        public virtual Category Category { get; set; }
        public virtual Film Film { get; set; }
    }
}