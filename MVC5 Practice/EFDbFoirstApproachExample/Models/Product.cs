using EFDbFoirstApproachExample.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFoirstApproachExample.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name required")]
        [MaxLength(30, ErrorMessage = "Product Name can be a maximum of 30 characters")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price required")]
        [Range(0, 100000, ErrorMessage = "Price needs to be between 0 and 100000")]
        [DivisibleBy10(ErrorMessage = "Please enter a value divisible by 10")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Date Of Purchase")]
        [DataType("Date")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Display(Name = "Availability Status")]
        public string AvailabilityStatus { get; set; }

        [Display(Name = "Category ID")]
        [Required(ErrorMessage = "Category required")]
        public Nullable<long> CategoryID { get; set; }

        [Display(Name = "Brand ID")]
        [Required(ErrorMessage = "Brand required")]
        public Nullable<long> BrandID { get; set; }

        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}