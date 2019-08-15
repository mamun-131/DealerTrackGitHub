using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DealerTrack.Context;
using DealerTrack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

/**
 * This is a .NET CORE interview coding challnge application
 * 
 * @FileName: VechicleSoldController.cs
 * @Author Md Mamunur Rahman
 * @Phone: 6474473215
 * @website: http://mamun-portfolio.azurewebsites.net/Default.aspx
 * @Last Update 14-Auguet-2019
 * @description: this file is Controller clss file for the Web Api
 */

namespace DealerTrack.Controllers
{
    /**  
     * <summary>  
     * This is the VechicleSoldController class for controlling data query operation from csv file.  
     * </summary>  
     * @class VechicleSoldController  
     */
    [Route("api/[controller]")]
    public class VechicleSoldController : Controller
    {
        //PRIVATE INSTANCE OBJECT/VARIABLE++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++e
        private ILogger _log;
        private readonly IVechicleSoldRepository _vechicleSoldRepository;
        private IHostingEnvironment _env;

        //CONSTRUCTOR++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This is the Constructor for initialiging the private variables
        * </summary>
        * @Constructor VechicleSoldController
        * @param {interface IVechicleSoldRepository} vechicleSoldRepository
        * @param {interface ILoggerFactory} loggerFactory
        * @param {interface IHostingEnvironment} env
        */
        public VechicleSoldController(IVechicleSoldRepository vechicleSoldRepository, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            _vechicleSoldRepository = vechicleSoldRepository;
            _log = loggerFactory.CreateLogger<VechicleSoldController>();
            _env = env;
        }

        //PUBLIC METHODES++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This is the public API method for making query to get all vechical sold infomation 
        * </summary>
        * @method GetAllVechicleSoldInformation
        * @returns {IEnumerable<VechicleSold>} 
        */
        [HttpGet("[action]")]
        public IEnumerable<VechicleSold> GetAllVechicleSoldInformation()
        {
            return _vechicleSoldRepository.GetAllVechicleSoldInfo().AsEnumerable();
        }
        /**
        * <summary>
        * This is the public API method for making query to get most often vechical sold infomation 
        * </summary>
        * @method MostOftenVechicleSoldInfo
        * @returns {IEnumerable<VechicleSold>} 
        */
        [HttpGet("[action]")]
        public IEnumerable<VechicleSold> MostOftenVechicleSoldInfo()
        {
            return _vechicleSoldRepository.MostOftenVechicleSoldInfo().AsEnumerable();
        }
        /**
        * <summary>
        * This is the public API method for uploading file 
        * </summary>
        * @method FileUpload
        * @param {interface IFormFile} file
        * @returns {InterIActionResult} 
        */
        [HttpPost("[action]")]
        public IActionResult FileUpload(IFormFile file)
        {
            var dir = _env.ContentRootPath;
            //To save file into UpLoadedFiles folder as file.csv
            using (var fileStream = new FileStream(Path.Combine(dir, "UpLoadedFiles/file.csv"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            return Ok(file);
        }
    }
}