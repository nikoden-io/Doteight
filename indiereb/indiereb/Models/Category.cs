using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace indiereb.Models;

public class Category
{
    [Key] // Optional if  the field is name "Id" or "{ClassName}Id"
    public int CategoryId { get; set; }

    [Required]
    [DisplayName("Category Name")]
    [MaxLength(30)]
    public string Name { get; set; }

    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "Custom message: from 1 to 100 only")]
    public int DisplayOrder { get; set; }
}