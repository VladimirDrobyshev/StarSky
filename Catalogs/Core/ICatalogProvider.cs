namespace Core;

/// <summary>
/// Интерфейс для получения данных каталога
/// </summary>
public interface ICatalogProvider
{
    /// <summary>
    /// Название каталога
    /// </summary>
    public string CatalogName { get; }
    /// <summary>
    /// Возвращает список имен частей каталога
    /// </summary>
    /// <returns>Возвращает список имен частей каталога</returns>
    Task<List<string>> GetPartsAsync();
    /// <summary>
    /// Получить часть каталога
    /// </summary>
    /// <param name="partName">Имя части каталога</param>
    /// <returns>Возвращает список StarInfo для всех звезд в части каталога</returns>
    Task<IList<StarInfo>> GetPartAsync(string partName);
}