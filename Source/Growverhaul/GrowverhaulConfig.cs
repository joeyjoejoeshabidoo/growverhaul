using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Growverhaul
{
    public class GrowverhaulConfig : Def
    {
        internal static Dictionary<RecipeDef, MemeDef> MemesByRecipe = new();
        private List<IdeoDependency> ideoLocks;

        internal static GrowverhaulConfig Config => DefDatabase<GrowverhaulConfig>.GetNamed("MainConfig");

        internal void Load()
        {
            foreach (var ideoDependency in ideoLocks)
            {
                foreach (var recipe in ideoDependency.recipeUnlocks)
                {
                    MemesByRecipe.TryAdd(recipe, ideoDependency.memeDef);
                }
            }
        }

        internal class IdeoDependency
        {
            internal MemeDef memeDef;
            internal List<RecipeDef> recipeUnlocks;
        }
    }
}
