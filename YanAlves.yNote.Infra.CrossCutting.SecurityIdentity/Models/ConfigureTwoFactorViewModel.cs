using System.Collections.Generic;

namespace YanAlves.yNote.Infra.CrossCutting.Security.Models
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<string> Providers { get; set; }
    }
}