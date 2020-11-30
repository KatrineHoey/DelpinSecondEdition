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
            [Required(ErrorMessage = "Ressource Id mangler.")]
            public Guid ResourceId { get; set; }

            [Required(ErrorMessage = "Ressource navn mangler.")]
            public string ResourceName { get; set; }

            [Required(ErrorMessage = "Ressource nummer mangler.")]
            public int ResourceNo { get; set; }

            [Required(ErrorMessage = "Ressource pris mangler.")]
            public int ResourcePrice { get; set; }

            [Required(ErrorMessage = "Er slettet mangler.")]
            public bool IsDeleted { get; set; }
        }
    }
}
