using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.Data.Sqlite;

namespace estonian_companies
{
    class Program
    {
        static async Task Main(string[] args)
        {   

            try
            {
                var inputUrl = args[0];
                var year = Convert.ToInt32(args[1]);
                var quarter = Convert.ToInt32(args[2]);
                await DownloadCustomerDataFile(inputUrl,year,quarter);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static async Task<bool> SaveToTable(List<EmtaData> customerDatas)
        {
            using (var db = new CustomerDataContext())
            {
                try
                {
                    await db.AddRangeAsync(customerDatas);
                    await db.SaveChangesAsync();
                    Console.WriteLine("Record saved to db");
                    return true;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;                    
                }
            }
        }

        private static async Task<bool> DownloadCustomerDataFile(string url, int year, int quarter)
            {
                try
                {
                    var uri = new Uri(url);
                    List<EmtaData> customerDataList = new List<EmtaData>();
                    HttpClient client = new HttpClient();
                    var responseStream = await client.GetStreamAsync(uri);
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                    using (var memoryStream = new MemoryStream())
                    {
                        await responseStream.CopyToAsync(memoryStream);

                        memoryStream.Position = 0;
                        using (var reader = ExcelReaderFactory.CreateReader(memoryStream))
                        {
            
                            do
                            {
                                while (reader.Read())
                                {
                                if (reader.Depth > 0) {
                                    EmtaData customerData = new EmtaData
                                    {
                                        RegistryCode = string.IsNullOrEmpty(reader.GetValue(0).ToString()) ? "": reader.GetValue(0).ToString(),
                                        Name = string.IsNullOrEmpty(reader.GetValue(1).ToString()) ? "": reader.GetValue(1).ToString(),
                                        StateTax = ConvertEmtaData(reader.GetValue(6)?.ToString()),
                                        WorkforceTax = ConvertEmtaData(reader.GetValue(7)?.ToString()),
                                        Revenue = ConvertEmtaData(reader.GetValue(8)?.ToString()),
                                        EmployeeCount = ConvertEmtaData(reader.GetValue(9)?.ToString()),
                                        Year = year,
                                        Quarter = quarter,
                                        YearQuarter = year.ToString() + '-'+ quarter.ToString()                                            
                                    };
                                        customerDataList.Add(customerData);
                                    }
                        
                                }
                            } while (reader.NextResult());
                            await SaveToTable(customerDataList);

                        }
                    }
    
                }
                catch (System.Net.WebException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                return false;
            }

            private static decimal ConvertEmtaData(string input)
            {
                try
                {
                    if (input == string.Empty) {
                        return 0;
                    }
                    return Convert.ToDecimal(string.IsNullOrEmpty(input) ? "0" : input);
                }
                catch (System.Exception)
                {
                    return 0;
                    
                }
            }
    }
}
