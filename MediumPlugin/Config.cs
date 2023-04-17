using Exiled.API.Interfaces;
using System.ComponentModel;

namespace MediumPlugin
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;

        [Description("Количесто вызовов МОГ через Интерком. По умолчанию: 1")]
        public int CountSpawnMFT { get; set; } = 1;
    }
}
