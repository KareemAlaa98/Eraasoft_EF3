using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_BikeStore.Models;

[Keyless]
public partial class NewView
{
    [Column("category_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string CategoryName { get; set; } = null!;

    [Column("p_count")]
    public int? PCount { get; set; }

    [Column("production_count")]
    [StringLength(4)]
    [Unicode(false)]
    public string ProductionCount { get; set; } = null!;
}
