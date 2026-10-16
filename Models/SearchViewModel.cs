using System;
using System.ComponentModel.DataAnnotations;

namespace Joo_Jeana_HW3.Models
{
    public enum PriceSearchType { [Display(Name = "Greater Than")] GreaterThan, [Display(Name = "Less Than")] LessThan }

    public class SearchViewModel
    {
        // Search both Title and Author
        [Display(Name = "Search by Title or Author:")]
        public String? SearchName { get; set; }

        // Search Description
        [Display(Name = "Search by Description:")]
        public String? SearchDescription { get; set; }

        // Format (Dropdown)
        [Display(Name = "Book Format:")]
        public Format? SearchFormat { get; set; }

        // Genre (Dropdown) - We store the ID of the selected genre
        [Display(Name = "Genre:")]
        public Int32 SelectedGenreID { get; set; }

        // Price (Textbox + Radio Buttons)
        [Display(Name = "Search by Price:")]
        [Range(0, 1000, ErrorMessage = "Please enter a valid price.")]
        public Decimal? SearchPrice { get; set; }

        [Display(Name = "Price Search Type:")]
        public String PriceType { get; set; }

        // Released After (Date Picker)
        [Display(Name = "Released On or After:")]
        [DataType(DataType.Date)]
        public DateTime? SearchDate { get; set; }
        public String DateType { get; set; }
    }
}