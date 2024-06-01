using Newtonsoft.Json;

namespace FlashcardApp.Common;

public class LocalStorageRepository<TEntity> : IRepository<TEntity>
    where TEntity : IEntity
{
    private readonly string _pathToDirectory;
    private readonly JsonSerializerSettings _readJsonSettings;
    private readonly JsonSerializerSettings _writeJsonSettings;

    public LocalStorageRepository(
        string pathToDirectory)
    {
        _pathToDirectory = pathToDirectory;
        _readJsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
        };
        _writeJsonSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented
        };
    }

    public async Task<TEntity> GetBy(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return default;

        if (!Directory.Exists(_pathToDirectory))
            Directory.CreateDirectory(_pathToDirectory);

        if (!Directory.Exists(_pathToDirectory))
            return default;

        string filePath = CreateFilePath(_pathToDirectory, id);

        try
        {
            var fileText = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<TEntity>(fileText, _readJsonSettings);
        }
        catch (Exception)
        {
            return default;
        }
    }

    public Task<TEntity[]> GetBy(IList<string> ids)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity[]> GetAll()
    {
        if (!Directory.Exists(_pathToDirectory))
            Directory.CreateDirectory(_pathToDirectory);

        string[] filePaths = Directory.GetFiles(_pathToDirectory);
        if (filePaths == null || filePaths.Length == 0)
            return Array.Empty<TEntity>();

        var fileTexts = filePaths.Select(File.ReadAllText);
        var entities = fileTexts.Select(ft => JsonConvert.DeserializeObject<TEntity>(ft, _readJsonSettings)).ToArray();

        return entities;
    }

    public async Task<bool> Create(TEntity item) 
    {
        if (item is null || string.IsNullOrWhiteSpace(item.Id))
            return false;

        string filePath = CreateFilePath(_pathToDirectory, item.Id);

        if (File.Exists(filePath))
            return false;

        var fileData = JsonConvert.SerializeObject(item, _writeJsonSettings);
        try
        {
            File.WriteAllText(filePath, fileData);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Create(IEnumerable<TEntity> items)
    {
        return false;
    }

    public async Task<bool> Update(TEntity item)
    {
        if (item is null || string.IsNullOrWhiteSpace(item.Id))
            return false;

        string filePath = CreateFilePath(_pathToDirectory, item.Id);

        if (!File.Exists(filePath))
            return false;

        item.Version++;
        var fileData = JsonConvert.SerializeObject(item, _writeJsonSettings);

        try
        {
            File.WriteAllText(filePath, fileData);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Delete(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return false;

        string filePath = CreateFilePath(_pathToDirectory, id);
        if (!File.Exists(filePath))
            return false;

        try
        {
            File.Delete(filePath);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static string CreateFilePath(string pathToDirectory, string name) =>
        pathToDirectory.Trim('\\', '/') + '/' + name;
}
