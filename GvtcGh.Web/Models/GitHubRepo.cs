using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GvtcGh.Web.Models
{

    [DataContract(Name = "Repo")]
    public class GitHubRepo
    {
        [Display(Name = "Repository Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Repository Name Must be Supplied")]
        public string Name { get; set; }

        [Display(Name = "Repository Owner")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Repository Owner Must be Supplied")]
        public string Owner { get; set; }

    }
}