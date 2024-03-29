using System.ComponentModel.DataAnnotations;

namespace VClients.Api.DTOs;

public class AdressDto
{
    public int Id { get; set; }
    
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    public string Address { get; set; }
    
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string City { get; set; }
    [Required]
    
    [MinLength(1)]
    [MaxLength(50)]
    public string State { get; set; }
    
    [Required]
    [MinLength(1)]
    [MaxLength(20)]
    public string Zip { get; set; }
    
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string Country { get; set; }
}