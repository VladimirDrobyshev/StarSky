namespace Core;

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
    /// Возвращает список файлов на странице
    /// </summary>
    /// <param name="parser">Функиция фильтрации по именам файлов в ссылках</param>
    /// <param name="extension">Расширение файлов</param>
    /// <returns>Возвращает список файлов с учетом фильтра</returns>
    public async Task<IEnumerable<string>> GetFileNames(string extension, Func<Stream, string, IEnumerable<string>> parser)
    {
        await using var stream = await new HttpClient().GetStreamAsync(_uri);
        return parser(stream, extension);
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