using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.IO;
namespace Anbar.Download
{
    public class ToDownload
    {
        public static readonly string mypath = Path.Combine("wwwroot/text", "Allitems.txt");
        public ToDownload(string name,string price,string description)
        {
            File.AppendAllText(mypath, $"\n{name}:{price}:{description}");
        }
        public static void RemoveText()
        {
            File.WriteAllText(mypath, string.Empty);
        }
        public static void IfEmpty()
        {
            if(new FileInfo(mypath).Length==0)
            {
                File.WriteAllText(mypath, " لیست محصولات خالی است");
            }
        }
       
    }
}
