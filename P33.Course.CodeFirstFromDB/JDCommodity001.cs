namespace P33.Course.CodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //using attributing mapping 
    [Table("JD_Commodity_001")]
    public partial class JDCommodity001
    {
        public int Id { get; set; }

        public long? ProductId { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(500)]
        [Column("Title")]//use attribute mapping
        public string Text { get; set; }

        public decimal? Price { get; set; }

        [StringLength(1000)]
        public string Url { get; set; }

        [StringLength(1000)]
        public string ImageUrl { get; set; }
    }
}
