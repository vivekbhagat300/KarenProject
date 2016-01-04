using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KarenProject.Models
{
    
    public class section1Model
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
   

        [Required]
        [Display(Name = "Date Joined")]
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
       [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        [Display(Name = "Sales Person")]
        public string SalesPerson { get; set; }
        [Required]
        [Display(Name = "Referred By")]
        public string RefferedBy { get; set; }
        [Required]

        public string Competition { get; set; }
        [Required]
        [Display(Name = "Id Status")]
        public string IdStatus { get; set; }
        public string Company { get; set; }
        [Required]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Project Address")]
        public string ProjAdress { get; set; }
       
         [Display(Name = "Address")]
        public string ContactAdress { get; set; }
        [Required]
         [Display(Name = "State")]
        public string ProjState { get; set; }
       // [Required]
         [Display(Name = "State")]
        public string ContactState { get; set; }
        [Required]
         [Display(Name = "Suburb")]
        public string ProjectSuburb { get; set; }
      
         [Display(Name = "Suburb")]
        public string ContactSuburb { get; set; }
        [Display(Name = "Post Code")]
        public string ProjPostCode { get; set; }
         [Display(Name = "Post Code")]
        public string ContactPostCode { get; set; }
        [Required]
        public string ProjectType { get; set; }
        public virtual ICollection<MainQuote> MainList { get; set; }
      //  public virtual ICollection<LVGquote> LVGquote { get; set; }
    }
}