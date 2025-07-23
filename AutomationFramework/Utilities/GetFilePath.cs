using System.Xml.Linq;
using Dynamitey;

namespace AutomationFramework.Utilities
{
    public class GetFilePath
    {
        public static string FilePath(string fileName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectDir, fileName);
            return filePath;
        }
    }
}

