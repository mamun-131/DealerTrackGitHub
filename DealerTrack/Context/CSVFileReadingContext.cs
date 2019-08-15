using DealerTrack.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
/**
 * This is a .NET CORE interview coding challnge application
 * 
 * @FileName: CSVFileReadingContext.cs
 * @Author Md Mamunur Rahman
 * @Phone: 6474473215
 * @website: http://mamun-portfolio.azurewebsites.net/Default.aspx
 * @Last Update 14-Auguet-2019
 * @description: this file is a clss file for reading CVS files and data cleaning
 */
namespace DealerTrack.Context
{
    /**  
     * <summary>  
     * This is the CSVFileReadingContext class for reading CVS files and data cleaning  
     * </summary>  
     * @class CSVFileReadingContext  
     */
    public class CSVFileReadingContext
    {
        //CONSTRUCTOR++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This is the empty Constructor
        * </summary>
        * @Constructor CSVFileReadingContext
        */
        public CSVFileReadingContext() { }

        //PUBLIC METHODES++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This is the public method for making query to get all vechical sold infomation 
        * </summary>
        * @method GetVechicleSoldCSVData
        * @param {string} path
        * @returns {List<VechicleSold>} 
        */
        public List<VechicleSold> GetVechicleSoldCSVData(string path)
        {
            List<VechicleSold> vechicleSoldCSVData = new List<VechicleSold>();
            try
            {
                string csvdata = File.ReadAllText(path);
                csvdata = CleanCSVData(csvdata);
                int rowcount = 0;
                foreach (string row in csvdata.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (rowcount > 0)
                        {
                            vechicleSoldCSVData.Add(new VechicleSold
                            {
                                DealNumber = Convert.ToInt32(row.Split(',')[0].Replace("^", "")),
                                CustomerName = row.Split(',')[1].Replace("^", ","),
                                DealershipName = row.Split(',')[2].Replace("^", ","),
                                Vehicle = row.Split(',')[3].Replace("^", ","),
                                Price = Convert.ToDecimal(row.Split(',')[4].Replace("^", "")),
                                Date = Convert.ToDateTime(row.Split(',')[5].Replace("^", ""))
                            });
                        }
                        rowcount++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vechicleSoldCSVData;
        }
        //PRIVATE METHODES++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This is the private method for cleaning the cvs file data, particularly to ignore the "," inside the double quoted value 
        * for example the DealerShipName "Legowart Kingorty, Ltd." that has a coma inside which create prolem for coma delimited spliting
        * </summary>
        * @method CleanCSVData
        * @param {string} csvdata
        * @returns {string} 
        */
        private string CleanCSVData(string csvdata)
        {
            bool isQuoted1 = false;
            bool isQuoted2 = false;
            string cleandata = "";
            foreach (char chr in csvdata)
            {
                if (!isQuoted1 && !isQuoted2)
                {
                    if (chr == '"')
                    {
                        cleandata = cleandata + "";
                        isQuoted1 = true;
                    }
                    else
                    {
                        cleandata = cleandata + chr;
                    }
                }
                else if (isQuoted1 && !isQuoted2)
                {
                    if (chr == ',')
                    {
                        cleandata = cleandata + "^";
                    }
                    else
                    {
                        if (chr == '"')
                        {
                            cleandata = cleandata + "";
                            isQuoted2 = true;
                        }
                        else
                        {
                            cleandata = cleandata + chr;
                        }

                    }
                }
                if (isQuoted1 && isQuoted2)
                {
                    isQuoted1 = false;
                    isQuoted2 = false;
                }
            }
            return cleandata;
        }
    }
}
