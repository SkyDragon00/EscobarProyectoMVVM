using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EscobarProyectoMVVM.EscobarViewsModels
{
    internal class EscobarAboutViewModels
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://www.youtube.com/watch?v=tgbNymZ7vqY";
        public string Message => "Esta app fue hecha por Domenica Escobar";
        public ICommand ShowMoreInfoCommand { get; }

        public EscobarAboutViewModels()
        {
            ShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
        }

        async Task ShowMoreInfo() =>
            await Launcher.Default.OpenAsync(MoreInfoUrl);
    }
}
