// Decompiled with JetBrains decompiler
// Type: TakeBoth.PerkSelectionPatch
// Assembly: TakeBoth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F73DE5F3-FDB2-4CD0-B463-210D6185E6D1
// Assembly location: C:\Users\Pyro\Desktop\TakeBoth.dll

using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;

namespace TakeBoth
{
  [HarmonyPatch(typeof (SkillVM), "OnPerkSelectionOver")]
  public class PerkSelectionPatch
  {
    private static bool Prefix(SkillVM __instance, PerkVM perk)
    {
      if (perk.AlternativeType == 0)
        return false;
      ((IEnumerable<PerkVM>) __instance.Perks).SingleOrDefault<PerkVM>((Func<PerkVM, bool>) (p => p.Perk == perk.Perk.AlternativePerk)).PerkState = 3;
      return false;
    }
  }
}
