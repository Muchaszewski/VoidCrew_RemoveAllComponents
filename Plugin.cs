using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace VoidCrew_RemoveAllComponents
{
    [BepInPlugin("com.muchaszewski.voidcrew_removeallcomponents", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }
    }
}