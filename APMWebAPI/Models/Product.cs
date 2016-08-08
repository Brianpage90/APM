using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace APM.WebAPI.Models
{
    public class Product
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is Required", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "Product Name min length is 5 characters")]
        [MaxLength(11)]
        public string ProductName { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}