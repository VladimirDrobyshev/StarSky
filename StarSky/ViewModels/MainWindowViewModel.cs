using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive.Concurrency;
using GDR3;
using ReactiveUI; //TODO VD: Replace straight reference with dll loader
using StarSky.Models;

namespace StarSky.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    readonly StarCatalogModel _model = new(new Gdr3CatalogProvider()); 
        
    public string Greeting => "Welcome to Avalonia!";
    public IEnumerable<string>? Parts => _model.Parts;  

    public MainWindowViewModel()
    {
        _model.PropertyChanged += StarCatalogModelPropertyChanged;
        RxApp.MainThreadScheduler.Schedule(LoadParts);
    }
    void StarCatalogModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(StarCatalogModel.Parts))
            this.RaisePropertyChanged(nameof(Parts));
    }
    async void LoadParts() => await _model.LoadParts();
}