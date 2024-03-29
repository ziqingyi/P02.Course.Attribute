using System.Data.Entity.ModelConfiguration;

namespace P33.Course.CodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JDCommodity003
    {
        public int Id { get; set; }

        public long? ProductId { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(500)]
        public string Text { get; set; }

        public decimal? Price { get; set; }

        [StringLength(1000)]
        public string Url { get; set; }

        [StringLength(1000)]
        public string ImageUrl { get; set; }
    }

    public class JDCommodity003Mapping : EntityTypeConfiguration<JDCommodity003>
    {
        public JDCommodity003Mapping()
        {
            this.ToTable("JD_Commodity_003");
            this.Property(c => c.Text).HasColumnName("Title");
        }
    }

}
