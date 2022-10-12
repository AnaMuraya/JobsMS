using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagementPortal.Models
{
    public class JobAction
    {

        public int JobActionId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        //NOTE: All of my date properties need validation..

        [DisplayFormat(DataFormatString = @"{0:MM\/dd\/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        [Display(Name = "Ordered Date")]
        public DateTime? OrderedDate { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = @"{0:MM\/dd\/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Delivery Date")]
        public DateTime? DeliveryDate { get; set; }

        //NOTE: I used to have 'StartDateTime' and 'EndDateTime' as nullable DateTime, but every time I tried to save
        //      in {0:MM/dd/yyyy hh:mm:ss tt} among many other for ways to format, I kept hitting the 
        //      'throw new Exception(value.AttemptedValue + " is not a valid date");' in the DatetimeModelBinder.cs under
        //      the 'Validation' folder. This happened when editing the seed data and when creating a JobAction entity 
        //      when trying to include date AND time (if you saved only the date, the validation went through).
        //NOTE: My next idea was to find a Date AND Time picker that the user can use to save a string and then manually 
        //      validate the string values afterwards. I nearly accomplished it using this link:
        //      http://www.skimedic.com/blog/post/2015/04/03/Using-a-DateTime-Picker-for-ASPNET-MVC-5-with-Bootstrap.aspx
        //      However, we are using the newest Bootstrap version 4.3.1 for this project and there aren't many date AND time  
        //      pickers Bootstrap 4. 
        //NOTE: Something like this would be awesome https://trentrichardson.com/examples/timepicker/ (go to the 'Examples' tab).

        [Display(Name = "Start Date and Time")]
        public string StartDateTime { get; set; }

        [Display(Name = "End Date and Time")]
        public string EndDateTime { get; set; }

        [StringLength(1000)]
        public string URL { get; set; }

        public virtual Job Job { get; set; } //A job Action can only have one job.




    }
}