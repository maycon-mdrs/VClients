namespace VClients.Api.Models;

public class Client
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Adress? Adress { get; set; }
}