// Decompiled with JetBrains decompiler
// Type: TakeBoth.TakeBothBehavior
// Assembly: TakeBoth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F73DE5F3-FDB2-4CD0-B463-210D6185E6D1
// Assembly location: C:\Users\Pyro\Desktop\TakeBoth.dll

using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;

namespace TakeBoth
{
  public class TakeBothBehavior : CampaignBehaviorBase
  {
    private void TryAddAllAlternatePerks(Hero hero)
    {
      foreach (PerkObject perkObject in ((IEnumerable<PerkObject>) PerkObject.All).Where<PerkObject>((Func<PerkObject, bool>) (perk => !hero.GetPerkValue(perk) && perk.AlternativePerk != null && hero.GetPerkValue(perk.AlternativePerk))))
        hero.HeroDeveloper.AddPerk(perkObject);
    }

    private void OnGameLoadFinishedEvent()
    {
      foreach (Hero aliveHero in Campaign.Current.AliveHeroes)
        this.TryAddAllAlternatePerks(aliveHero);
    }

    public virtual void RegisterEvents()
    {
      CampaignEvents.OnGameLoadFinishedEvent.AddNonSerializedListener((object) this, new Action(this.OnGameLoadFinishedEvent));
      CampaignEvents.HeroCreated.AddNonSerializedListener((object) this, new Action<Hero, bool>(this.HeroCreated));
      CampaignEvents.PerkOpenedEvent.AddNonSerializedListener((object) this, new Action<Hero, PerkObject>(this.OnPerkOpened));
    }

    private void HeroCreated(Hero hero, bool bornNaturally)
    {
      if ((double) hero.Age < 18.0)
        return;
      this.TryAddAllAlternatePerks(hero);
    }

    private void OnPerkOpened(Hero hero, PerkObject perk)
    {
      if (perk.AlternativePerk == null || hero.HeroDeveloper.GetPerkValue(perk.AlternativePerk))
        return;
      hero.HeroDeveloper.AddPerk(perk.AlternativePerk);
    }

    public virtual void SyncData(IDataStore dataStore)
    {
    }
  }
}
