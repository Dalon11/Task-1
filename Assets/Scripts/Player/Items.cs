using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask keyLayerMask, doorLayerMask;

    [SerializeField] UI gameCanvas;

    [SerializeField] bool isInventory = false;
    public GameObject[] keys= new GameObject[2];
    public GameObject useKey;

    Vector2 rayCameraCenter = new Vector2(Screen.width / 2, Screen.height / 2);

    #region Start/Update
    void Start()
    {
        gameCanvas = FindObjectOfType<UI>();
    }
    void Update()
    {
        TakeKey();
        Inventory();
        UseDoor();
    }
    #endregion
    void TakeKey()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(rayCameraCenter);
        Physics.Raycast(ray, out RaycastHit hitKey, rayDistance, keyLayerMask);
        if (hitKey.collider != null)
        {
            gameCanvas.ImageButtonE();
            if (Input.GetKeyDown(KeyCode.E) && (!keys[0] || !keys[1]))
            {

                var key= hitKey.transform.gameObject;
                if (keys[0] == null)
                {
                    keys[0] = hitKey.transform.gameObject;
                    gameCanvas.Item(key, 0);
                    hitKey.transform.gameObject.SetActive(false);
                    
                }
                else
                {
                    keys[1] = hitKey.transform.gameObject;
                    gameCanvas.Item(key, 1);
                    hitKey.transform.gameObject.SetActive(false);
                    
                }
            }

        }
        else gameCanvas.ImageButtonE(false);
    }
    void UseDoor()
    {
        Ray ray = Camera.main.ScreenPointToRay(rayCameraCenter);
        Physics.Raycast(ray, out RaycastHit hitDoor, rayDistance, doorLayerMask);
        if (hitDoor.collider != null && useKey)
        {
            gameCanvas.ImageButtonE();
            if (Input.GetKeyDown(KeyCode.E))
            {
                var door = hitDoor.transform.GetComponent<Doors>();
                var useKeyType = useKey.GetComponent<Keys>();
                if ((int)door.doorLock == (int)useKeyType.keyType) door.DoorColors();
                else  door.DoorColors(false);



                //if(useKey.name == keys[0].name && !keys[0])
                //{
                //    gameCanvas.DropUseItem(0);
                //    Destroy(keys[0]);
                //    keys[0] = null;
                //}
                //useKey = null;

                for (int i = 0; i < keys.Length; i++)
                {
                    if (!keys[i]) continue;
                    if (useKey.name == keys[i].name)
                    {
                        
                        gameCanvas.DropUseItem(i);
                        Destroy(keys[i]);

                    }
                }


            }
        }
        else gameCanvas.ImageButtonE(false);
    }

    void Inventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isInventory)
        {
            Player.isCanMove = false;
            isInventory = true;
            Cursor.visible = true;
            gameCanvas.InventoryPanel();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isInventory)
        {
            Player.isCanMove = true;
            isInventory = false;
            Cursor.visible = false;
            gameCanvas.InventoryPanel(false);
        }

    }

    
   
}
