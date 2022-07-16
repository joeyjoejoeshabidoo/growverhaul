using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Verse;

namespace Growverhaul
{
    public class GrowverhaulMod : Mod
    {
        private Harmony instance;

        public GrowverhaulMod(ModContentPack content) : base(content)
        {
            Log.Message("Init Growverhaul");
            instance = new Harmony("Joeyjoejoeshabidoo.Growverhaul");
            instance.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
