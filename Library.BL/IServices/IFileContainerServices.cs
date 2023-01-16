using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BL.IServices
{
    public interface IFileContainerServices
    {
        // return list of files with info
        List<FileContainer> GetAllFileContainers();
        
        // return one item or more searching 
        List<FileContainer> GetByName(string name);

        bool AddFile(FileContainer file);

        bool DeleteFile(FileContainer file);
        bool UpdateFile(FileContainer updateFile , int id);


    }
}
