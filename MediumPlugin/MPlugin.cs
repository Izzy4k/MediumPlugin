using Exiled.API.Features;
using MediumPlugin.Features;
using System;

namespace MediumPlugin
{
    public sealed class MPlugin : Plugin<Config>
    {
        private static readonly Lazy<MPlugin> LazyPlugin = new Lazy<MPlugin>(() => new MPlugin());

        public static MPlugin Instance { get; private set; } = LazyPlugin.Value;

        private static readonly Lazy<JailController> LazyJail = new Lazy<JailController>(() => new JailController());

        public static JailController JailController => LazyJail.Value;

        private static readonly Lazy<IntercomController> LazyIntercom = new Lazy<IntercomController>(() => new IntercomController());

        public static IntercomController IntercomController => LazyIntercom.Value;
    }
}