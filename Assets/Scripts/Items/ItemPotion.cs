using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Items
{
    public class ItemPotion : ItemModel
    {
        public ItemPotion(int index)
        {
            SetInventoryIndex(index);
            Init();
        }

        public ItemPotion()
        {
            Init();
        }

        void Init()
        {
            
            SetItemType(ItemType.Item);
            AddEffect(new Effect(EffectType.Heal));
            SetItemName("Small Healing Potion");
            SetHeal(10);
        }
    }
}
