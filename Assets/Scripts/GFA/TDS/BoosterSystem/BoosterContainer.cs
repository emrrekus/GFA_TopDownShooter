using System;
using System.Collections;
using System.Collections.Generic;
using GFA.TDS.BoosterSystem;
using Unity.VisualScripting;
using UnityEngine;

public class BoosterContainer : MonoBehaviour
{
   private List<Booster> _boosters = new List<Booster>();
   
   public event Action<Booster> BoosterAdded; 
   
   public void AddBooster(Booster booster)
   {
      _boosters.Add(booster);
      booster.OnAdded(this);
   }
}
