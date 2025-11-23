using System.Text.Json;

namespace ShkoloClone.Data
{
    public abstract class JsonDbContext
    {
        private readonly string _filePath;
        private readonly Dictionary<string, object> _cachedLists = new();

        protected JsonDbContext(string filePath)
        {
            _filePath = filePath;
            Load();
        }

        protected Dictionary<string, object> Data { get; set; } = new();

        public void SaveChanges()
        {
            foreach (var kvp in _cachedLists)
            {
                Data[kvp.Key] = kvp.Value;
            }

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
            if (_cachedLists.ContainsKey(name) && _cachedLists[name] is List<T> cachedList)
            {
                return cachedList;
            }

            List<T> list;
            if (!Data.ContainsKey(name))
            {
                list = new List<T>();
            }
            else
            {
                list = JsonSerializer.Deserialize<List<T>>(
                    JsonSerializer.Serialize(Data[name])
                ) ?? new List<T>();
            }

            _cachedLists[name] = list;
            return list;
        }
    }

}
