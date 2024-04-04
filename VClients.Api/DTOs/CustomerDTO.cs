using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VClients.Api.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The FullName field is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string FullName { get; set; }
    
    [Required(ErrorMessage = "The Email field is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "The Phone field is required")]
    [MinLength(5)]
    [MaxLength(20)]
    public string Phone { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public FullAddressDTO? FullAddress { get; set; }
}