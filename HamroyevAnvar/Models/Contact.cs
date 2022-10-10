using System.ComponentModel.DataAnnotations;

namespace HamroyevAnvar.Models;

public class Contact
{
    [MinLength(5)]
    public string FullName { get; set; }
    [MinLength(7)]
    public string Tel { get; set; }
    [MinLength(4)]
    public string Subject { get; set; }
    [MinLength(5), MaxLength(500)]
    public string Text { get; set; }
}
