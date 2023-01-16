using Library.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;


namespace Library.Data.Entities
{
    public class FileContainer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string FolderPath { get; set; }
        public string UserName { get; set; }
        public FileType FileType { get; set; }
        public DateTime DateOfUploaded { get; set; }

    }
}
