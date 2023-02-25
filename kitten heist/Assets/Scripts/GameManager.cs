using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject ItemObtainedScreen;
    public Image icon;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public GameObject InteractText;

    public GameObject InventoryScreen;
    public GameObject inventoryItemPrefab;
    public GameObject inventoryContentHead;

    // Start is called before the first frame update
    void Start()
    {
        gm = this;
    }

    public void ShowInventory()
    {
        InventoryScreen.SetActive(true);
    }
    public void CloseInventory()
    {
        InventoryScreen.SetActive(false);
    }

    public void AddToInventory(Item i)
    {
        var invI = Instantiate(inventoryItemPrefab, inventoryContentHead.transform);
        invI.GetComponent<InventoryItem>().init(i);
    }

    public void ShowItemObtained(Item i)
    {
        Time.timeScale = 0;
        title.text = i.title;
        description.text = i.description;
        icon.sprite = i.itemIcon;
        ItemObtainedScreen.SetActive(true);
    }

    public void CloseItemObtained()
    {
        Time.timeScale = 1f;
        ItemObtainedScreen.SetActive(false);
    }

    public void TurnOnInteractText()
    {
        if (!InteractText.activeInHierarchy)
        {
            InteractText.SetActive(true);
        }
    }
    public void TurnOffInteractText()
    {
        if (InteractText.activeInHierarchy)
        {
            InteractText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
