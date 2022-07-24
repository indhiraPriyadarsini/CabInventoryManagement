using System.ComponentModel.DataAnnotations;

namespace CabInventoryManagement.Models
{
    public class testClass
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
