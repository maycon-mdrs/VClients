using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VClients.Api.Models;

namespace VClients.Api.DTOs;

public class FullAddressDTO
{
    [JsonIgnore]
    public int Id { get; set; }
    
    [JsonIgnore]
    public int? CustomerId { get; set; }
    [JsonIgnore]
    public Customer? Customer { get; set; }
    
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