namespace ESD_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chart")]
    public partial class Chart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChartId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? UserId { get; set; }

        public int? MajorId { get; set; }

        public int? PostId { get; set; }

        public int? AcademicYearId { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }

        public virtual Major Major { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
