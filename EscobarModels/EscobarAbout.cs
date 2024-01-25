using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscobarProyectoMVVM.EscobarModels
{
    internal class EscobarAbout
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://www.youtube.com/watch?v=iSbLHrrqmoM";
        public string Message => "Esta app fue hecha por Domenica Escobar";
    }
}
