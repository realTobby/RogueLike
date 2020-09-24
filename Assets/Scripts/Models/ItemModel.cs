using Assets.Scripts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public enum ItemType
    {
        Waepon,
        Armor,
        Item
    }


    public class ItemModel : IItem
    {
        public bool isFull;
        private string itemName;
        private ItemType itemType;
        private int damage;
        private int defense;
        private List<Effect> effects;
        private int heal;
        private int inventoryIndex;
        private bool isStackable;
        private int stackSize;

        public ItemModel()
        {
            Init();
        }

        public void Convert(IItem item)
        {
            ItemModel concreteItem = item as ItemModel;

            isFull = concreteItem.isFull;
            itemName = concreteItem.itemName;
            itemType = concreteItem.itemType;
            damage = concreteItem.damage;
            defense = concreteItem.defense;
            effects = concreteItem.effects;
            heal = concreteItem.heal;
            inventoryIndex = concreteItem.inventoryIndex;
        }

        void Init()
        {
            isFull = false;
            itemName = "???";
            heal = 0;
            damage = 0;
            defense = 0;
            effects = new List<Effect>();
            itemType = ItemType.Item;
        }

        public void AddEffect(Effect effect)
        {
            effects.Add(effect);
        }

        public int GetDamage()
        {
            return damage;
        }

        public int GetDefense()
        {
            return defense;
        }

        public List<Effect> GetEffects()
        {
            return effects;
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        public void SetDefense(int defense)
        {
            this.defense = defense;
        }

        public void SetItemType(ItemType itemType)
        {
            this.itemType = itemType;
        }

        public void SetHeal(int heal)
        {
            this.heal = heal;
        }

        public int GetHeal()
        {
            return heal;
        }
        public void SetItemName(string name)
        {
            itemName = name;
        }
        public string GetItemName()
        {
            return itemName;
        }

        public void SetInventoryIndex(int index)
        {
            inventoryIndex = index;
        }

        public int GetInventoryIndex()
        {
            return inventoryIndex;
        }

        public bool GetIsFull()
        {
            return isFull;
        }

        public void SetIsFull(bool value)
        {
            isFull = value;
        }

        public void Discard()
        {

            if(IsStackable())
            {
                if (stackSize <= 0)
                {
                    Init();
                }
                else
                {
                    SetStackSize(GetStackSize() - 1);
                }
            }
            else
            {
                Init();
            }
        }

        public void SetStackable(bool value)
        {
            isStackable = value;
        }

        public bool IsStackable()
        {
            return isStackable;
        }

        public int GetStackSize()
        {
            return stackSize;
        }

        public void SetStackSize(int value)
        {
            stackSize = value;
        }
    }
}
