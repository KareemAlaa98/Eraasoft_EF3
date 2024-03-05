using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_BikeStore.Models;

[Table("notificationss", Schema = "sales")]
public partial class Notificationss
{
    [Key]
    [Column("notification_id")]
    public int NotificationId { get; set; }

    [Column("message")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Message { get; set; }

    [Column("date", TypeName = "datetime")]
    public DateTime? Date { get; set; }
}
