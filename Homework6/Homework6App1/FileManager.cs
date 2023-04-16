using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6App1
{
    public static class FileManager
    {
    public static List<DirectoryItem> GetDirectoryContents(string dirName)
        {
            var content = new List<DirectoryItem>();

            var directories = Directory.GetDirectories(dirName);
            foreach (var directory in directories)
            {
                content.Add(new DirectoryItem(
                    DirectoryItem.ItemTypes.Directory,
                    directory.Remove(0, dirName.Length + 1), 
                    Directory.GetLastWriteTime(dirName)));
            }

            var files = Directory.GetFiles(dirName);
            
            content.AddRange(files.Select(
                file => new DirectoryItem(
                    Type: DirectoryItem.ItemTypes.File,
                    Name: file.Remove(0, dirName.Length + 1), 
                    DateLastChange: File.GetLastWriteTime(file))));

            return content;
        }

        public static async Task ForceRecordToNewFileAsync(string filePath, string content)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"Удален существующий файл {filePath}");
            }

            await using var writer = new StreamWriter(filePath);
            await writer.WriteAsync(content);
            Console.WriteLine($"\"{content}\" записано в {filePath}");
        }
   }
}

