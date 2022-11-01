using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoperCsvParser
{
    public class ExportedDataDTO
    {
        public IEnumerable<Product>? Products { get; set; }
    }
    public class Product
    {
        public string? Code { get; set; }
        public string? Barcode { get; set; }
        public string? Unit { get; set; }
        public string? Category { get; set; }
        public string? Weight { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }
        public byte[]? Image1 { get; set; }
        public byte[]? Image2 { get; set; }
        public byte[]? Image3 { get; set; }
        public byte[]? Image4 { get; set; }
        public byte[]? Image5 { get; set; }
        public byte[]? Image6 { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDescription { get; set; }
        public string? SeoKeyWords { get; set; }
        public string? SeoUrl { get; set; }
    }
}
