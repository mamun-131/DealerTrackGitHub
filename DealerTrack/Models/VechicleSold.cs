using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
 * This is a .NET CORE interview coding challnge application
 * 
 * @FileName: VechicleSold.cs
 * @Author Md Mamunur Rahman
 * @Phone: 6474473215
 * @website: http://mamun-portfolio.azurewebsites.net/Default.aspx
 * @Last Update 14-Auguet-2019
 * @description: this file is data model clss
 */
namespace DealerTrack.Models
{
    /**  
     * <summary>  
     * This is the VechicleSold Model class to create the VechicleSold Object.  
     * </summary>  
     * @class VechicleSold
     */
    public class VechicleSold
    {
        public int DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string Vehicle { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
