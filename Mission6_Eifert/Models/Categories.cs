using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Eifert.Models;

public class Categories
{
    [Key]
    [Column("CategoryId")]
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
}