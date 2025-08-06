using RenameQuranSuraName;
using System.Text;

class Program
{
    static void Main()
    {
        var surahNames = SurahName.GetSurahNames();

        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("ادخل مسار الفولدر: ");
        string folderPath = Console.ReadLine()!;

        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine("المسار غير موجود!");
            return;
        }

        var files = Directory.GetFiles(folderPath);

        foreach (var file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            string extension = Path.GetExtension(file);

            if (fileName.Contains('-'))
            {
                Console.WriteLine($"⏩ تم تخطي الملف لأنه معاد تسميته بالفعل: {fileName}");
                continue;
            }

            if (IsFileLocked(file))
            {
                Console.WriteLine($"⚠ لا يمكن إعادة تسمية الملف لأنه مفتوح: {fileName}");
                continue;
            }

            if (int.TryParse(fileName, out int surahNumber) && surahNames.ContainsKey(surahNumber))
            {
                string newFileName = $"{surahNumber}- {surahNames[surahNumber]}{extension}";
                string newPath = Path.Combine(folderPath, newFileName);

                // تجنب الخطأ إذا الملف الجديد موجود بالفعل
                if (File.Exists(newPath))
                {
                    Console.WriteLine($"⚠ الملف الهدف موجود بالفعل، تم التخطي: {newFileName}");
                    continue;
                }

                File.Move(file, newPath);
                Console.WriteLine($"تم إعادة تسمية: {fileName} → {newFileName}");
            }
            else
            {
                Console.WriteLine($"⚠ لم يتم التعرف على: {fileName}");
            }
        }

        Console.WriteLine("✅ انتهى العمل.");
    }

    static bool IsFileLocked(string path)
    {
        try
        {
            using FileStream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            return false;
        }
        catch (IOException)
        {
            return true;
        }
    }
}