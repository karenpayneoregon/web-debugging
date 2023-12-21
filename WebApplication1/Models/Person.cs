using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace WebApplication1.Models;

/// <summary>
/// Not part of the DbContext
/// </summary>
public class Person
{
    public int Id { get; set; }
    [Required]
    public string BusinessName { get; set; }
    [Required]
    public string AccountNumber { get; set; }
    [Required]
    public string ContactPerson { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string ZipCode { get; set; }
    
    public int State { get; set; }
}
