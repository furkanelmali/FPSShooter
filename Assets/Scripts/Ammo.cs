using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    [SerializeField] ammoSlot[] ammoSlots;
    

    [System.Serializable]
    private class ammoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int getCurrentAmmo(AmmoType ammoType) 
    {
        return getAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType) 
    {
        getAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseCurrentAmmo()
    {
        getAmmoSlot(AmmoType.Bullets).ammoAmount += 12;
        getAmmoSlot(AmmoType.Shells).ammoAmount += 60;
    }

    private ammoSlot getAmmoSlot(AmmoType ammoType) 
    {
        foreach(ammoSlot slot in ammoSlots) 
        {
            if(slot.ammoType == ammoType) 
            {
                return slot;            
            }
        } 
        return null;
    
    }
}
