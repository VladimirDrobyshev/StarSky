using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Core;

namespace StarSky.Models;

/// <summary>
/// Модель звездного каталога
/// </summary>
public class StarCatalogModel : INotifyPropertyChanged
{
    readonly ICatalogProvider _provider;
    List<string>? _parts;

    public string Name => _provider.CatalogName;
    public List<string>? Parts
    {
        get => _parts;
        private set => SetField(ref _parts, value);
    }

    public StarCatalogModel(ICatalogProvider provider)
    {
        _provider = provider;
    }
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return;
        field = value;
        OnPropertyChanged(propertyName);
    }
    #endregion
    public async Task LoadParts() => Parts = await _provider.GetPartsAsync();
}