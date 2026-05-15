using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using InventoryApp.Models;

namespace InventoryApp.Services
{
    public class InventoryService
    {
        private readonly string _filePath = "data.json";

        public async Task<List<Item>> GetItemsAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Item>();
            }

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Item>>(json) ?? new List<Item>();
        }

        public async Task SaveItemAsync(Item item)
        {
            var items = await GetItemsAsync();
            items.Add(item);
            
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(items, options);
            
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
