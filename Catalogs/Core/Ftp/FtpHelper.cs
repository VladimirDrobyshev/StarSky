namespace Core.Ftp;

/// <summary>
/// Вспомогательны класс для работы с FTP
/// </summary>
public class FtpHelper
{
    readonly Uri _uri;

    /// <summary>
    /// Создает новый экземпляр класса FtpHelper 
    /// </summary>
    /// <param name="uri">Uri FTP ресурса</param>
    public FtpHelper(Uri uri)
    {
        _uri = uri;
    }
    /// <summary>
    /// Возвращает список файлов 
    /// </summary>
    /// <param name="filter">Фильтр по именам файлов</param>
    /// <returns>Возвращает список файлов с учетом фильтра</returns>
    public async Task<List<string>> GetFileNames(Predicate<string> filter)
    {
        var result = new List<string>();
        using var client = new HttpClient();
        await using var stream = await client.GetStreamAsync(_uri);
        if (stream != null)
        {
            using var streamReader = new StreamReader(stream);
            var line = await streamReader.ReadLineAsync();
            while (!string.IsNullOrEmpty(line))
            {
                if (filter(line))
                    result.Add(line);
                line = await streamReader.ReadLineAsync();
            }
            
        }
        return result;
    }
}