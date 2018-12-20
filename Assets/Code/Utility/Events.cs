// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  SEPT 2018
// ----------------------------------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [Serializable] public class FadeComplete : UnityEvent<bool> { }
    [Serializable] public class SceneChangeComplete : UnityEvent<bool> { }
    [Serializable] public class PlayerDeath : UnityEvent<bool> { }
    [Serializable] public class InventorySlotSwap : UnityEvent<InventorySlot, InventorySlot> { }
    [Serializable] public class HullDisabled : UnityEvent<HullComponent> { }
    [Serializable] public class EngineDisabled : UnityEvent<EngineComponent> { }
    [Serializable] public class WeaponDisabled : UnityEvent<WeaponComponent> { }

}
