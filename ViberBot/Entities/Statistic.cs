using System.ComponentModel.DataAnnotations.Schema;

namespace ViberBot.Entities;

public class Statistic
{
    [Column("id", TypeName = "int")]
    public int? Id { get; set; }
    
    [Column("distance", TypeName = "decimal(6, 2)")]
    public decimal? Distance { get; set; }
    
    [Column("time_length", TypeName = "DATETIME")]
    public DateTime? TimeLength { get; set; }
}