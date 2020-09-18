using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public enum EffectType
    {
        Spell,
        SpellEffect,
        Heal
    }

    public class Effect
    {

        public EffectType EffectType;


        public Effect(EffectType effectType)
        {
            EffectType = effectType;
        }

    }
}
