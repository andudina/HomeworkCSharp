using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6App1
{
    public static class CsvManager
    {
        public static async Task RecordDirectoryContent(List<DirectoryItem> directoryItems, string fileName, string separator)
        {
            await using var writer = new StreamWriter(fileName);
            foreach (var directoryItem in directoryItems)
            {
                writer.WriteLine(
                    $"\"{directoryItem.Type}\"{separator}\"{directoryItem.Name}\"{separator}\"{directoryItem.DateLastChange}\"");
            }
        }
    }
}