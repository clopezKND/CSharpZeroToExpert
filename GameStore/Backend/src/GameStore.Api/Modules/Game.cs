using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Modules;

public class Game
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

        [Required]
    [StringLength(20)]
    public required string Genre { get; set; }

    [Required]
    [Range(0.01, 999.99)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
