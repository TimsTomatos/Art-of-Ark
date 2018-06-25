using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //Variables
    public bool inventoryEnabled;
    public GameObject inventory;
    public GameObject itemDatabase;
    private Transform[] slot;
    public GameObject slotHolder;

    private bool pickedUpItem;

   
    //Function
    public void Start()
    {
        GetAllSlots();
    }

    public void Update()
    {
        //Enabling and disabling the inventory
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled)
            inventory.SetActive(true);
        else
            inventory.SetActive(false);

    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
           
            AddItem(other.gameObject);
            print("Item triggered");
        }


    }


    public void AddItem(GameObject item)
    {
        GameObject rootItem;
        rootItem = item.GetComponent<ItemPickUp>().rootItem;

        for(int i=0; i < 25; i++)
        {
            if(slot[i].GetComponent<Slot>().empty == true && item.gameObject.GetComponent<ItemPickUp>().pickedUp == false)
            {
                slot[i].GetComponent<Slot>().item = rootItem;
                item.GetComponent<ItemPickUp>().pickedUp = true;
                Destroy(item);
            }

            
        }

    }

    public void GetAllSlots()
    {
        slot = new Transform[15]; //Intger Value = total slots
        for (int i = 0; i < 25; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
            print(slot[i].gameObject.name);
        }
    }
}
