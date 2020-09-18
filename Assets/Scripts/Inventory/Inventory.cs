using Assets.Scripts.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Models;

public class Inventory : MonoBehaviour
{

    public List<IItem> items = new List<IItem>();
    public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            items.Add(new ItemModel());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DiscardItem(int index)
    {
        items[index].Discard();
        Destroy(slots[index].transform.GetChild(0).gameObject);
    }

    public int GetFirstOpenSlotIndex()
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].GetIsFull() == false)
                return i;
        }
        return -1;
    }

}
