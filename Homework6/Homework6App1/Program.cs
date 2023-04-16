using System.IO.Compression;
using Homework6App1;

namespace Homework6;

static class Lesson6App1
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

    static async Task Main()
    {
        // 1. Распаковывает архив в папку рядом с запускаемым файлом программы
        try
        {
            Unzip(ArchiveName, UnarchDirectory);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Архива {ArchiveName} в директории программы не существует.");
            throw;
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Доступ к файлу {ArchiveName} запрещён. Измените атрибуты файла.");
            throw;
        }
        catch (InvalidDataException)
        {
            Console.WriteLine($"Файл {ArchiveName} не является архивом или повреждён.");
            throw;
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
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Доступ к директории {Path.GetFullPath(UnarchDirectory)} запрещён.");
            throw;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"Директория {Path.GetFullPath(UnarchDirectory)} была удалена");
            throw;
        }

        if (directoryContent.Count == 0)
        {
            throw new Exception("Исследуемый архив пуст.");
        }



        // 3. Записывает информацию о содержимом папки (тип (файл/папка), название, дата
        // изменения) в текстовый файл в формате .csv (разделитель – \t (знак табуляции) )
        try
        {
            await CsvManager.RecordDirectoryContent(
                directoryItems: directoryContent,
                fileName: CsvName,
                separator: Separator);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Файл {CsvName} защищен от записи. Измените его атрибуты.");
            throw;
        }
        catch (IOException)
        {
            Console.WriteLine($"Файл {CsvName} открыт в другом приложении.");
            throw;
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
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"Директория {UnarchDirectory} уже не существует.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Директория {UnarchDirectory} защищена от изменений.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        // 5. Сохраняет путь к файлу csv в файле %AppData%/Lesson12Homework.txt
        try
        {
            await FileManager.ForceRecordToNewFileAsync(
                filePath: Environment.ExpandEnvironmentVariables(PathToTemporaryFile),
                content: Path.GetFullPath(CsvName));
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Доступ к файлу {PathToTemporaryFile} запрещён.");
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}

