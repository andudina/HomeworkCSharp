using Homework5App1;
using System.IO.Compression;

namespace Homework5;

static class Lesson5App1
{
    const string ArchiveName = "archive.zip";
    const string UnarchDirectory = "archive";
    const string CsvName = "DirectoryItemsList.csv";
    const string Separator = @"\t";
    const string PathToTemporaryFile = @"%AppData%\Lesson12Homework.txt";

    static void Unzip(string archiveName, string unarchDirectory)
    {
        if (Directory.Exists(unarchDirectory))
        {
            Directory.Delete(unarchDirectory, true);
        }

        ZipFile.ExtractToDirectory(sourceArchiveFileName: archiveName,
            destinationDirectoryName: unarchDirectory);
        Console.WriteLine($"Распакован архив {archiveName}");
    }

    static void Main()
    {
        // 1. Распаковывает архив в папку рядом с запускаемым файлом программы
        try
        {
            Unzip(ArchiveName, UnarchDirectory);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        // 2. Считывает названия файлов и папок из указанной папки
        List<DirectoryItem> directoryContent;

        try
        {
            directoryContent = FileManager.GetDirectoryContents(UnarchDirectory);
        }

        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


        // 3. Записывает информацию о содержимом папки (тип (файл/папка), название, дата
        // изменения) в текстовый файл в формате .csv (разделитель – \t (знак табуляции) )
        try
        {
            CsvManager.RecordDirectoryContent(
                directoryItems: directoryContent,
                fileName: CsvName,
                separator: Separator);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        // 4. Удаляет папку с распакованным архивом
        try
        {
            Directory.Delete(UnarchDirectory, true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        // 5. Сохраняет путь к файлу csv в файле %AppData%/Lesson12Homework.txt
        try
        {
            FileManager.ForceRecordToNewFile(
                filePath: Environment.ExpandEnvironmentVariables(PathToTemporaryFile),
                content: Path.GetFullPath(CsvName));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
