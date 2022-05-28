using System;
using System.Collections.Generic;

namespace MovieStoreUI.Entities
{
    public class Director:Person
    {
        public ICollection<Movie> Movies { get; set; }
        
        
    }
}