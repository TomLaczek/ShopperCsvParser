using HtmlAgilityPack;
using System.Text;

namespace ShoperCsvParser
{
    public class CsvParser
    {
        private string CsvPath { get; set; }
        public CsvParser(string path)
        {
            CsvPath = path;
        }
        public async Task<ExportedDataDTO> ParseCsvFile()
        {
            Console.WriteLine("Starting CSV Parser");
            Product lineData;
            ExportedDataDTO exportedData = new();
            var dataList = new List<Product>();
            var hap = new HtmlDocument();
            var imageParser = new ImageParser();

            const Int32 BufferSize = 128;
            using var fileStream = File.OpenRead(CsvPath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            string line = string.Empty;
            string[] splittedLine;
            int i = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (i > 0)
                {
                    hap.LoadHtml(line);
                    var hapLine = HtmlEntity.DeEntitize(hap.DocumentNode.InnerText.Replace("&nbsp;", " ").Replace(";</li>", ". </li>")); 
                    splittedLine = hapLine.Split(';');
                    lineData = await MapSpilltedData(splittedLine, imageParser);
                    dataList.Add(lineData);
                }
                i++;
            }
            exportedData.Products = dataList;
            Console.WriteLine($"Finish parsing\n\rParsed lines {i}");
            return exportedData;
        }

        private async static Task<Product> MapSpilltedData(string[] splittedLine, ImageParser imgParser)
        {
            return new Product
            {
                Code = splittedLine[0],
                Barcode = splittedLine[1],
                Unit = splittedLine[2],
                Category = splittedLine[3],
                Weight = splittedLine[4],
                Name = splittedLine[5],
                ShortDescription = splittedLine[6],
                Description = splittedLine[7],
                Price = splittedLine[8],
                Image1 = !string.IsNullOrEmpty(splittedLine[9]) ? await imgParser.GetImage(splittedLine[9]) : null,
                Image2 = !string.IsNullOrEmpty(splittedLine[10]) ? await imgParser.GetImage(splittedLine[9]) : null,
                Image3 = !string.IsNullOrEmpty(splittedLine[11]) ? await imgParser.GetImage(splittedLine[9]) : null,
                Image4 = !string.IsNullOrEmpty(splittedLine[12]) ? await imgParser.GetImage(splittedLine[9]) : null,
                Image5 = !string.IsNullOrEmpty(splittedLine[13]) ? await imgParser.GetImage(splittedLine[9]) : null,
                Image6 = !string.IsNullOrEmpty(splittedLine[14]) ? await imgParser.GetImage(splittedLine[9]) : null,
                SeoTitle = splittedLine[15],
                SeoDescription = splittedLine[16],
                SeoKeyWords = splittedLine[17],
                SeoUrl = splittedLine[18]
            };
        }
    }
}