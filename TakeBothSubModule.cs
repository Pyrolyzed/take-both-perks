// Decompiled with JetBrains decompiler
// Type: TakeBoth.TakeBothSubModule
// Assembly: TakeBoth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F73DE5F3-FDB2-4CD0-B463-210D6185E6D1
// Assembly location: C:\Users\Pyro\Desktop\TakeBoth.dll

using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace TakeBoth
{
  public class TakeBothSubModule : MBSubModuleBase
  {
    protected virtual void OnBeforeInitialModuleScreenSetAsRoot()
    {
      try
      {
        new Harmony("TakeBoth").PatchAll();
        InformationManager.DisplayMessage(new InformationMessage("Successfully loaded Take Both", Colors.Green));
      }
      catch (Exception ex)
      {
        InformationManager.DisplayMessage(new InformationMessage("Failed to load Take Both!", Colors.Red));
        Debug.Print(ex.ToString(), 0, (Debug.DebugColor) 12, 17592186044416UL);
      }
    }

    protected virtual void OnGameStart(Game game, IGameStarter gameStarterObject)
    {
      if (!(game.GameType is Campaign))
        return;
      ((CampaignGameStarter) gameStarterObject).AddBehavior((CampaignBehaviorBase) new TakeBothBehavior());
    }
  }
}
