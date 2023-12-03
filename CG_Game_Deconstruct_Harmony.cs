using CG.Client.Player.Interactions.Build;
using CG.Client.Ship.Interactions;
using CG.Game.Player;
using CG.Ship.Modules;
using HarmonyLib;

namespace VoidCrew_RemoveAllComponents;

/// <summary>
///     Add a deconstruction leaver to all cell modules.
///     Kept in FixedUpdate because initialization hook is tricky for the mediator.
/// </summary>
[HarmonyPatch(typeof(CellModule), "FixedUpdate")]
public class CG_Game_CellModule_FixedUpdate_Harmony
{
    [HarmonyPrefix]
    public static void Prefix(ref CellModule __instance)
    {
        if (!__instance.BuildingConstraints.allowDeconstruction)
        {
            __instance.BuildingConstraints.allowDeconstruction = true;
            var componentInChildren = __instance.GameObject.GetComponentInChildren<ModuleDeconstructButton>(true);
            if ((bool)componentInChildren)
            {
                componentInChildren.gameObject.SetActive(true);
                var module = __instance;
                componentInChildren.GetComponent<ExtruderLever>().LeverThresholdTriggerEvent.AddListener(
                    () => { BuildProcessController.Instance.DeconstructModule(LocalPlayer.Instance, module); });
            }
        }
    }
}