using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using SimpleToDoListAvalonia.Models;

namespace SimpleToDoListAvalonia.Services
{
    public static class ToDoListFileService
    {
      private static string _jsonFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "Avalonia.SimpleToDoListAvalonia", "MyToDoList.txt");

        public static async Task SaveToFileAsync(IEnumerable<ToDoItem> itemsToSave)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_jsonFileName)!);

            using (var fs = File.Create(_jsonFileName))
            {
                await JsonSerializer.SerializeAsync(fs, itemsToSave);
            }
        }
    }
}
