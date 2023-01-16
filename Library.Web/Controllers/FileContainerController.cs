using Library.BL.IServices;
using Library.Data.Entities;
using Library.Data.Enums;
using Library.Web.Models.Files;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Library.Web.Controllers
{
    public class FileContainerController : Controller
    {
        private readonly IHtmlHelper htmlHelper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly SignInManager<IdentityUser> signIn;
        private readonly IFileContainerServices fileServices;

        public FileContainerController(IHtmlHelper htmlHelper ,IHostingEnvironment hostingEnvironment,
                                       SignInManager<IdentityUser> signIn,
                                       IFileContainerServices fileServices) 
        {
            this.htmlHelper = htmlHelper;
            this.hostingEnvironment = hostingEnvironment;
            this.signIn = signIn;
            this.fileServices = fileServices;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            IEnumerable<SelectListItem> fileTypeList;
            fileTypeList = htmlHelper.GetEnumSelectList<FileType>();
            ViewBag.FileTypeList= fileTypeList;
            return View();
        }

        [HttpPost]
        public IActionResult Upload(FileContainerHelperModel model)
        {
            if (ModelState.IsValid) 
            {
                if (model.TheFile != null)
                {
                    string Filename;
                    string FolderPath = Path.Combine(hostingEnvironment.WebRootPath + "/Files");
                    Filename = Guid.NewGuid() + model.TheFile.Name;
                    string filePath = Path.Combine(FolderPath, Filename);
                    model.TheFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    // this part is to set the parent class info 
                    var ObjFileContaoner = new FileContainer
                    {
                        Name=model.TheFile.Name,
                        Description = model.Description,
                        FileType = model.FileType,

                        UserName = User.Identity.Name,
                        DateOfUploaded=DateTime.Now,
                        FilePath=filePath,
                        FolderPath=FolderPath,
                    };
                    bool result= fileServices.AddFile(ObjFileContaoner);
                    if (result)
                    {
                        // you should go to details 
                        return RedirectToAction("Index","home");
                    }
                    return RedirectToAction("privacy", "home");

                }
                return View(model);

            }
            return View(model);
        }

        //[HttpGet]
        //public IActionResult List() 
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult List()
        //{
        //    return View();
        //}
    }
}
