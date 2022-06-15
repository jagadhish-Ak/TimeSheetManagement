using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TimeSheetManagementProject.Models;

namespace TimeSheetManagementProject.Models
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string  Role { get; set; }
    }

    public class TimeSheetDetails
    {
        [Required]

        public string Day { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public int hours { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int Id { get; set; }


    }

   
}