using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace Growverhaul
{
    [StaticConstructorOnStartup]
    internal static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            GrowverhaulConfig.Config.Load();
        }

        //
        [HarmonyPatch(typeof(RecipeDef))]
        [HarmonyPatch(nameof(RecipeDef.AvailableNow),MethodType.Getter)]
        public static class AvailableNowPatch
        {
            public static void Postfix(RecipeDef __instance, ref bool __result)
            {
                if (GrowverhaulConfig.MemesByRecipe.TryGetValue(__instance, out var meme))
                {
                    __result = Faction.OfPlayer.ideos.PrimaryIdeo.HasMeme(meme);
                }
            }
        }
    }
}
