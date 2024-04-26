using System.ComponentModel.DataAnnotations;

namespace BlazorWasmMiniProject.Models;

public class AddressModel
{
    [Required]
    public string StreetAddress { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Region { get; set; }

    [Required]
    public string PostalCode { get; set; }
}
