using Colossal.IO.AssetDatabase;
using Game;
using Game.Modding;
using Game.SceneFlow;

namespace ExtraHotkeys
{
    public class Mod : IMod
    {
        public static ModSettings ModSettings;

        public void OnLoad(UpdateSystem updateSystem)
        {
            LogUtil.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                LogUtil.Info($"Current mod asset at {asset.path}");

            ModSettings = new ModSettings(this);
            ModSettings.RegisterInOptionsUI();
            ModSettings.RegisterKeyBindings();

            AssetDatabase.global.LoadSettings(nameof(ExtraHotkeys), ModSettings, new ModSettings(this));
            ModSettings.ApplyAndSave();

            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(ModSettings));

            updateSystem.UpdateAt<UISystem>(SystemUpdatePhase.UIUpdate);
        }

        public void OnDispose()
        {
            LogUtil.Info($"{nameof(Mod)}.{nameof(OnDispose)}");

            if (ModSettings != null)
            {
                ModSettings.UnregisterInOptionsUI();
                ModSettings = null;
            }
        }
    }
}
