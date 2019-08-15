using DealerTrack.Context;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
/**
 * This is a .NET CORE interview coding challnge application
 * 
 * @FileName: VechicleSoldRepository.cs
 * @Author Md Mamunur Rahman
 * @Phone: 6474473215
 * @website: http://mamun-portfolio.azurewebsites.net/Default.aspx
 * @Last Update 14-Auguet-2019
 * @description: this file is IVechicleSoldRepository interface implimentation class
 */
namespace DealerTrack.Models
{
    /**  
     * <summary>  
     * This is the VechicleSoldRepository class for implimenting IVechicleSoldRepository interface.  
     * </summary>  
     * @class VechicleSoldRepository  
     */
    public class VechicleSoldRepository : IVechicleSoldRepository
    {
        //PRIVATE INSTANCE OBJECT/VARIABLE++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++e
        private List<VechicleSold> _vechicleSold;
        private CSVFileReadingContext csvFileReadingContext;
        private IHostingEnvironment _env;

        //CONSTRUCTOR++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This is the Constructor for initialiging the private variables
        * </summary>
        * @Constructor VechicleSoldRepository
        * @param {interface IHostingEnvironment} env
        */
        public VechicleSoldRepository(IHostingEnvironment env)
        {
            _env = env;         
            csvFileReadingContext = new CSVFileReadingContext();
            _vechicleSold = csvFileReadingContext.GetVechicleSoldCSVData(Path.Combine(_env.ContentRootPath , "UpLoadedFiles/file.csv"));
        }

        //PUBLIC METHODES++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This is the public method for making query to get all vechical sold infomation 
        * </summary>
        * @method GetAllVechicleSoldInfo
        * @returns {List<VechicleSold>} 
        */
        public List<VechicleSold> GetAllVechicleSoldInfo()
        {
            return _vechicleSold;
        }
        /**
        * <summary>
        * This is the public method for making query to get most often vechical sold infomation 
        * </summary>
        * @method MostOftenVechicleSoldInfo
        * @returns {List<VechicleSold>} 
        */
        public List<VechicleSold> MostOftenVechicleSoldInfo()
        {
            var mostOftenVechicleSoldInfo = _vechicleSold.GroupBy(v => v.Vehicle).OrderByDescending(g => g.Count()).Select(g => g.AsParallel()).First();
            return mostOftenVechicleSoldInfo.ToList();
        }

    }
}
