using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CountryApi.Repository.Models
{
    public partial class CountryItem
    {
        [Key]
        [Column("id")]
        [StringLength(50)]
        [Unicode(false)]
        public string Id { get; set; } = null!;
        [Column("Country")]
        [StringLength(15)]
        [Unicode(false)]
        public string Country { get; set; } = null!;
        [Column("description")]
        [StringLength(50)]
        [Unicode(false)]
        public string Description { get; set; } = null!;
        [Column("name")]
        [StringLength(20)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column("isDone")]
        public bool IsDone { get; set; }
    }
}
