using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeTeFood.Core
{
    //TODO Do sprawdzenia https://code.msdn.microsoft.com/windowsdesktop/Validation-in-MVVM-using-12dafef3
    public class Restaurant
    {
        public int ID { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }

        [Required]
        public CuisineType Cuisine { get; set; }

    }
}
