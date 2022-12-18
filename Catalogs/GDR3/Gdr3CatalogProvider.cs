using Core;
using Core.Ftp;

namespace GDR3;

/// <summary>
/// Каталог GAIA v3
/// </summary>
public class Gdr3CatalogProvider : ICatalogProvider
{
    const string GaiaUrl = "http://cdn.gea.esac.esa.int/Gaia/gdr3/gaia_source/";
    const string DataFileExtension = ".csv.gz";

    readonly HttpHelper _httpHelper = new(new Uri(GaiaUrl));

    public string CatalogName => "GAIA 3";

    public async Task<List<string>> GetPartsAsync() => await _httpHelper.GetFileNames(f => true);
    public Task<IList<StarInfo>> GetPartAsync(string partName)
    {
        throw new NotImplementedException();
    }
}