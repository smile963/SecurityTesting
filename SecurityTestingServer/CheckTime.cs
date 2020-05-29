namespace SecurityTestingServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CheckTime")]
    public partial class CheckTime
    {
        [StringLength(6)]
        public string Id { get; set; }

        [StringLength(20)]
        public string time { get; set; }
    }
}
