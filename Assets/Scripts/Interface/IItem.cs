using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
{
    public interface IItem
    {
        List<Effect> GetEffects();
        int GetDamage();
        int GetDefense();
        void AddEffect(Effect effect);
        void SetDamage(int damage);
        void SetDefense(int defense);
        void SetItemType(ItemType itemType);
        int GetHeal();
        void SetHeal(int heal);
        void SetItemName(string name);
        string GetItemName();
        void SetInventoryIndex(int index);
        int GetInventoryIndex();
        bool GetIsFull();
        void SetIsFull(bool value);
        void Convert(IItem item);
        void Discard();
        void SetStackSize(int value);
        int GetStackSize();
        void SetStackable(bool value);
        bool IsStackable();
    }
}
