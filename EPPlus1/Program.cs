using System;
using System.IO;
using System.Runtime.CompilerServices;
using EPPlus1.Classes;
using OfficeOpenXml;

namespace EPPlus1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //StandardCodesSamples.CreateNewFile();
            //StandardCodesSamples.CreateNewFileWithData();
            //ReadAndImportBackInNewWorkSheet();
            StandardCodesSamples.Sample1();
            Console.ReadLine();
        }

        /// <summary>
        /// First method reads the first sheet to a DataTable
        /// Second method writes back to same file in a new sheet
        ///
        /// For a real application methods above would be in one method
        /// </summary>
        private static void ReadAndImportBackInNewWorkSheet()
        {
            var table = StandardCodesSamples.Export();
            StandardCodesSamples.Import(table);
        }


        [ModuleInitializer]
        public static void InitializeStuff()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
    }

}
