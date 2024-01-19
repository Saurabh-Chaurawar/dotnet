using System.ComponenetModel.DataAnnotations

namespace Products.Models
{
    public class Product
    {
        [Key]
        public int Id{get;set;}
        [Required]
        public string Name{get;set}

        public string Category{get;set}

        public int Price{get;set}
    }
}