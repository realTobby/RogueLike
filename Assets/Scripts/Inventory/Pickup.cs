using Assets.Scripts.Interface;
using Assets.Scripts.Items;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private ItemModel pickupItemData;

    private Inventory inventory;

    public GameObject itemButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Inventory>();
        pickupItemData = new ItemPotion();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PLAYER"))
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                if(inventory.items[i].GetIsFull() == false)
                {
                    // ITEM CAN BE ADDED
                    pickupItemData.SetIsFull(true);
                    inventory.items[i] = pickupItemData as ItemPotion;
                    Instantiate(itemButtonPrefab, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
