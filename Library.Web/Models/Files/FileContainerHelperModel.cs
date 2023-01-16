using Library.Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models.Files
{
    public class FileContainerHelperModel
    {
        [Required(AllowEmptyStrings =false ,ErrorMessage ="Please Enter the File Name")]
        [MinLength(8,ErrorMessage ="The Name of this file must be more than 8 character")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter the description of this file ")]
        public string Description { get; set; }


        public FileType FileType { get; set; }

        public IFormFile TheFile { get; set; }
    }
}
