namespace Example.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class main_table
    {
        public int Id { get; set; }

        public int employee_id { get; set; }

        public virtual employee employee { get; set; }
    }
}
