using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_BikeStore.Models;

[Table("test_table")]
public partial class TestTable
{
    [Key]
    [Column("test_id")]
    public int TestId { get; set; }

    [Column("test_name")]
    [StringLength(10)]
    [Unicode(false)]
    public string? TestName { get; set; }
}
