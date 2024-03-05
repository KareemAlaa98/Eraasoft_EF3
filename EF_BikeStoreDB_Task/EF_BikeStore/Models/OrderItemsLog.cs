using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_BikeStore.Models;

[Table("order_items_log", Schema = "sales")]
public partial class OrderItemsLog
{
    [Key]
    [Column("log_id")]
    public int LogId { get; set; }

    [Column("item_id")]
    public int? ItemId { get; set; }

    [Column("product_id")]
    public int? ProductId { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("list_price", TypeName = "decimal(10, 2)")]
    public decimal? ListPrice { get; set; }

    [Column("discount", TypeName = "decimal(5, 2)")]
    public decimal? Discount { get; set; }

    [Column("insert_date", TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }
}
