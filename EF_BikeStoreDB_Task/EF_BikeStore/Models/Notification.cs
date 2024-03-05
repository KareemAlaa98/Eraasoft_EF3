using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_BikeStore.Models;

[Table("notifications", Schema = "sales")]
public partial class Notification
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
