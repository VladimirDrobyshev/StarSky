namespace Core.Ftp;

/// <summary>
/// Вспомогательны класс для работы с HttpHelper
/// </summary>
public class HttpHelper
{
    readonly Uri _uri;

    /// <summary>
    /// Создает новый экземпляр класса FtpHelper 
    /// </summary>
    /// <param name="uri">Uri FTP ресурса</param>
    public HttpHelper(Uri uri)
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
        using var streamReader = new StreamReader(stream);
        var line = await streamReader.ReadLineAsync();
        while (!string.IsNullOrEmpty(line))
        {
            if (filter(line))
                result.Add(line);
            line = await streamReader.ReadLineAsync();
        }

        return result;
    }
    /// <summary>
    /// Загрузать файл
    /// </summary>
    /// <param name="name">Имя файла</param>
    /// <returns>Возвращает содерживое файла в виде массива байт</returns>
    public async Task<byte[]> DownloadFile(string name)
    {
        using var client = new HttpClient();
        var fileUri = new Uri(_uri, name);
        return await client.GetByteArrayAsync(fileUri);
    }
}