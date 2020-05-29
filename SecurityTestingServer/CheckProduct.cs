namespace SecurityTestingServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CheckProduct")]
    public partial class CheckProduct
    {
        [StringLength(6)]
        public string Id { get; set; }

        [Required]
        public string MAC { get; set; }
    }
}
