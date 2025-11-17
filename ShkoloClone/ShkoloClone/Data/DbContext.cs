using System.Text.Json;

namespace ShkoloClone.Data
{
    public abstract class JsonDbContext
    {
        private readonly string _filePath;

        protected JsonDbContext(string filePath)
        {
            _filePath = filePath;
            Load();
        }

        protected Dictionary<string, object> Data { get; set; } = new();

        public void SaveChanges()
        {
            var json = JsonSerializer.Serialize(Data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }

        private void Load()
        {
            if (!File.Exists(_filePath))
            {
                Data = new Dictionary<string, object>();
                return;
            }

            var json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                Data = new Dictionary<string, object>();
                return;
            }

            Data = JsonSerializer.Deserialize<Dictionary<string, object>>(json)
                   ?? new Dictionary<string, object>();
        }

        protected List<T> Set<T>(string name)
        {
            if (!Data.ContainsKey(name))
                Data[name] = new List<T>();

            return JsonSerializer.Deserialize<List<T>>(
                JsonSerializer.Serialize(Data[name])
            )!;
        }

        protected void UpdateSet<T>(string name, List<T> list)
        {
            Data[name] = list;
        }
    }

}
