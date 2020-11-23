using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.ViewModel
{
    public class ResourceViewModel
    {
        public class ResourceDetails 
        {
            [Required(ErrorMessage = "Resource navn mangler.")]
            public string ResourceName { get; set; }

            [Required(ErrorMessage = "Resource nummer mangler.")]
            public int ResourceNo { get; set; }

            [Required(ErrorMessage = "Resource pris mangler.")]
            public decimal ResourcePrice { get; set; }

            [Required(ErrorMessage = "Er slettet mangler.")]
            public bool IsDeleted { get; set; }
        }
    }
}
