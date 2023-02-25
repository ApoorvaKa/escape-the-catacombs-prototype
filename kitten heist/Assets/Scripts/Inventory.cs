using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory i;
    public List<Item> itemsHeld;

    // Start is called before the first frame update
    void Start()
    {
        i = this;
    }

    public void obtainItem(Item i)
    {
        if (!itemsHeld.Contains(i) && i != null)
        {
            itemsHeld.Add(i);
            GameManager.gm.ShowItemObtained(i);
            GameManager.gm.AddToInventory(i);
        }
    }

    public void useItem(Item i)
    {
        if(itemsHeld.Contains(i)){

        } 
        else
        {
            // error
        }
    }
}
