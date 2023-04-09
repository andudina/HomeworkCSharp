using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5App1
{
    public static class CsvManager
    {
        public static void RecordDirectoryContent(List<DirectoryItem> directoryItems, string fileName, string separator)
        {
            using var writer = new StreamWriter(fileName);
            foreach (var directoryItem in directoryItems)
            {
                writer.WriteLine(
                    $"\"{directoryItem.Type}\"{separator}\"{directoryItem.Name}\"{separator}\"{directoryItem.DateLastChange}\"");
            }
        }
    }
}
