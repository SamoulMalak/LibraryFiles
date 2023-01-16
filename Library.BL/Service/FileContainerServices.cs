using Library.BL.IServices;
using Library.Data;
using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Library.BL.Service
{
   public class FileContainerServices : IFileContainerServices
    {
        private readonly DataContext context;
        public FileContainerServices(DataContext context)
        {
            this.context = context;
        }
        public bool AddFile(FileContainer file)
        {
            context.FileContainers.Add(file);
            int result = context.SaveChanges();
            return KnowReturn(result);
        }

        public bool DeleteFile(FileContainer file)
        {
            context.Remove(file);
            int result = context.SaveChanges();
            return KnowReturn(result);
        }

        public List<FileContainer> GetAllFileContainers()
        {
            List<FileContainer> files = new List<FileContainer>();
            return context.FileContainers.ToList();
        }

        public List<FileContainer> GetByName(string name)
        {
            List<FileContainer> files = new List<FileContainer>();
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return context.FileContainers.ToList();
            }
            else
            {

              files=  context.FileContainers.Where(x => x.Name.ToLower() == name.ToLower()).ToList();
            files.AddRange(context.FileContainers.Where(x=>x.Description.ToLower() == name.ToLower()).ToList());
                return files ;
            }
        }

        public bool UpdateFile(FileContainer updateFile, int id)
        {
            var oldFile=context.FileContainers.Find(id);
            if (oldFile != null)
            {
                oldFile.Description = updateFile.Description;
                oldFile.FilePath = updateFile.FilePath;
                oldFile.Name = updateFile.Name;
                oldFile.FileType = updateFile.FileType;
                oldFile.FolderPath = updateFile.FolderPath;
                oldFile.UserName = updateFile.UserName;
                int result = context.SaveChanges();
                return KnowReturn(result);
            }
            else return false;
        }

        private bool KnowReturn (int result)
        {
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
