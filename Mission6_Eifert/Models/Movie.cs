using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Eifert.Models;

// Class used to save data on a single movie
public class Movie
{
    public int MovieId { get; set; }
    public required string Title { get; set; }
    public int? CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Categories? Category { get; set; }
    public string? Director { get; set; }
    public int Year { get; set; }
    public string? Rating { get; set; }
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
}
