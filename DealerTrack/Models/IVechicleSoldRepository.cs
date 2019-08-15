using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
 * This is a .NET CORE interview coding challnge application
 * 
 * @FileName: IVechicleSoldRepository.cs
 * @Author Md Mamunur Rahman
 * @Phone: 6474473215
 * @website: http://mamun-portfolio.azurewebsites.net/Default.aspx
 * @Last Update 14-Auguet-2019
 * @description: this file is an interface clss file for data query implimentation
 */
namespace DealerTrack.Models
{
    /**  
     * <summary>  
     * This is the IVechicleSoldRepository interface for data query implimentation.  
     * </summary>  
     * @interface IVechicleSoldRepository  
     */
    public interface IVechicleSoldRepository
    {
        List<VechicleSold> GetAllVechicleSoldInfo();
        List<VechicleSold> MostOftenVechicleSoldInfo(); 
    }
}
