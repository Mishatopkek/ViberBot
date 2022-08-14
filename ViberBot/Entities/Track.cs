using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViberBot.Entities;

public class Track
{
    [Column("id", TypeName = "int")]
    public int Id { get; set; }
    
    [Required]
    [Column("ITEM", TypeName = "varchar(50)")]
    public string Imei { get; set; }
    
    [Required]
    [Column("lalitude", TypeName = "decimal(12, 9)")]
    public decimal Latitude { get; set; }
    
    [Required]
    [Column("longitude", TypeName = "decimal(12, 9)")]
    public decimal Longitude { get; set; }
    
    [Required]
    [Column("DateEvent", TypeName = "datetime")]
    public DateTime DateEvent { get; set; }
    
    [Required]
    [Column("date_track", TypeName = "datetime")]
    public DateTime DateTrack { get; set; }
    
    [Required]
    [Column("TypeSource", TypeName = "int")]
    public int TypeSource { get; set; }
}