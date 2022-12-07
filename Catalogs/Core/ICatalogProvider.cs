namespace Core;

/// <summary>
/// Интерфейс для получения данных каталога
/// </summary>
public interface ICatalogProvider
{
    /// <summary>
    /// Возвращает список имен частей каталога
    /// </summary>
    /// <returns>Возвращает список имен частей каталога</returns>
    List<string> GetParts();
    /// <summary>
    /// Получить часть каталога
    /// </summary>
    /// <param name="partName">Имя части каталога</param>
    /// <returns>Возвращает список StarInfo для всех звезд в части каталога</returns>
    Task<IList<StarInfo>> GetPartAsync(string partName);
}