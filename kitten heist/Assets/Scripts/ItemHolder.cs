using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public Item item;
    public GameObject representation;
    public bool hasPlayer = false;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (item != null && hasPlayer && Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 0, layer);
            if (hit)
            {
                TakeItem();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && item != null)
        {
            hasPlayer = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void TakeItem()
    {
        Inventory.i.obtainItem(item);
        if(representation != null)
        {
            Destroy(representation);
        }
        item = null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }
}
