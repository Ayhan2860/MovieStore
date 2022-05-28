using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreUI.Entities
{
   
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
    
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
        
        
    }
    
}