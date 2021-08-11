using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [SerializeField] GameObject player;
    Items playerItems;
    [SerializeField] GameObject txtWin;
    [SerializeField] GameObject imageButtonE, inventoryPanel;

    [SerializeField] Image item0, item1, useItem;
    GameObject key0, key1;


    [SerializeField] Sprite[] keysSprites;

    #region Start/Update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        playerItems =player.GetComponent<Items>();
    }
     void Update()
    {
        Win();
    }
    #endregion
    public void Item(GameObject key, int item)
    {
        int keySpriteID = (int)key.GetComponent<Keys>().keyType;

        if (item == 0)
        {
            item0.sprite = keysSprites[keySpriteID];
            key0 = key;
        }
        else if (item == 1)
        {
            item1.sprite = keysSprites[keySpriteID];
            key1 = key;
        }

    }
    public void UseItem0()
    {        
        useItem.sprite = item0.sprite;
        playerItems.useKey = playerItems.keys[0];       
        useItem.gameObject.SetActive(true);   
    }
    public void UseItem1()
    {       
        useItem.sprite = item1.sprite;
        playerItems.useKey = playerItems.keys[1];
        useItem.gameObject.SetActive(true);        
    }
    public void Drop(int item)
    {
        if (item == 0)
        {
            playerItems.keys[0] = null;
            item0.sprite = null;
            key0.transform.position = player.transform.position;
            key0.SetActive(true);

        }
        else if (item == 1)
        {
            playerItems.keys[1] = null;
            item1.sprite = null;
            key1.transform.position = player.transform.position;
            key1.SetActive(true);

        }
        playerItems.useKey = null;
    }
    public void ImageButtonE(bool active=true)
    {
        imageButtonE.SetActive(active);
    }
    public void InventoryPanel(bool active =true)
    {
        inventoryPanel.SetActive(active);
    }

   public void DropUseItem(int item)
    {
        useItem.sprite = null;
        
        useItem.gameObject.SetActive(false);
        if (item == 0) item0.sprite = null;
        else if (item == 1) item1.sprite = null;
    }
    void Win()
    {
        if (Doors.totalGreenDoor == 3) txtWin.SetActive(true);
    }
}
