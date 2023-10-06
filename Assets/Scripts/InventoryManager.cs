using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //inventory open or not indicator
    public bool isOpen;
    //list of item picked up
    public List<GameObject> items = new List<GameObject>();

    //inventory system window
    public GameObject ui_window;
    public Image[] item_images;

    //item description
    public Text item_info;
    public GameObject item_bg;
    public GameObject ui_description_window;
    public Image item_description_image;
    public Text item_description;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
            Cursor.visible = true;
        }
    }

    public void inventoryON()
    {
        ToggleInventory();
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;

        ui_window.SetActive(isOpen);
    }
    public void PickUp(GameObject item)
    {
        items.Add(item);

        Update_UI();
    }
    void Update_UI()
    {
        HideSlots();
        for (int i = 0; i < items.Count; i++)
        {
            item_images[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            item_images[i].gameObject.SetActive(true);
        }
    }

    void HideSlots()
    {
        foreach (var i in item_images) { i.gameObject.SetActive(false); }
    }
    public void showinfo(int id)
    {
        //set item image
        item_description_image.sprite = item_images[id].sprite;
        //set item name
        item_description.text = items[id].name;
        //show item info
        item_info.text = items[id].GetComponent<Interactables>().item_info;

        ui_description_window.SetActive(true);
        item_bg.gameObject.SetActive(true);
        item_description.gameObject.SetActive(true);
        item_info.gameObject.SetActive(true);
        item_description_image.gameObject.SetActive(true);
        

    }

    public void hideinfo()
    {
        
        item_bg.gameObject.SetActive(false);
        item_info.gameObject.SetActive(false);
        item_description.gameObject.SetActive(false);   
        item_description_image.gameObject.SetActive(false);
        ui_description_window.SetActive(true);
    }
}






