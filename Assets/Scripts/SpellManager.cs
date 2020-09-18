using Assets.Scripts.Interface;
using Assets.Scripts.Items;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void UseHealingItem(ItemPotion potion)
    {
        Debug.Log("Using Item: " + potion.GetItemName() + " and restoring " + potion.GetHeal() + " HP");
    }

    public void Use(IItem item)
    {
        foreach(var effect in item.GetEffects())
        {
            switch(effect.EffectType)
            {
                case EffectType.Heal:
                    UseHealingItem(item as ItemPotion);
                    break;
                case EffectType.Spell:
                    break;
            }
        }
    }
}
