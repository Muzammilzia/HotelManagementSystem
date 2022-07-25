using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.Models
{
    public class Login
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "This field is Required.")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is Required.")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string ErrorMessage { get; set; }
    }
}