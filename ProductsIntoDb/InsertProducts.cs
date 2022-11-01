using Dapper;
using ShoperCsvParser;
using System.Data;
using System.Data.SqlClient;

namespace ProductsIntoDb
{
    public class InsertProducts
    {
        private string Conn { get; set; }
        public InsertProducts(string conn)
        {
            Conn = conn;
        }

        public async Task InsertProductsToDb(IEnumerable<Product> products)
        {
            if(products.Any())
            {
                string procedureName= "AddProductProcedure";
                using var conn = new SqlConnection(Conn);
                conn.Open();

                DynamicParameters dp;
                int result;
                int counter=0;
                foreach (var item in products)
                {
                    dp = new DynamicParameters();
                    dp.Add("@code", item.Code);
                    dp.Add("@barcode", item.Barcode);
                    dp.Add("@unit", item.Unit);
                    dp.Add("@category", item.Category);
                    dp.Add("@weight", item.Weight);
                    dp.Add("@name", item.Name);
                    dp.Add("@shortdescription", item.ShortDescription);
                    dp.Add("@description", item.Description);
                    dp.Add("@price", item.Price);
                    dp.Add("@image1", item.Image1, DbType.Binary);
                    dp.Add("@image2", item.Image2, DbType.Binary);
                    dp.Add("@image3", item.Image3, DbType.Binary);
                    dp.Add("@image4", item.Image4, DbType.Binary);
                    dp.Add("@image5", item.Image5, DbType.Binary);
                    dp.Add("@image6", item.Image6, DbType.Binary);
                    dp.Add("@seotitle", item.SeoTitle);
                    dp.Add("@seodescription", item.SeoDescription);
                    dp.Add("@seokeywords", item.SeoKeyWords);
                    dp.Add("@seourl", item.SeoUrl);

                    result = await conn.ExecuteAsync(procedureName, dp, null, null, commandType: CommandType.StoredProcedure);
                    if (result.Equals(1))
                    {
                        Console.WriteLine($"Added {item.Name} product");
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to add {item.Name}");
                    }    
                };
                Console.WriteLine($"Successfully added {counter} products to DB");
            }
            else
            {
                Console.WriteLine("No products to insert");
            }
        }
    }
}