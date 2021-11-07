using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    #region KeyboardKeys
    readonly KeyCode keyboardKey—onfirm = KeyCode.E;
    readonly KeyCode keyboardKeyInventory = KeyCode.Tab;
    #endregion
    GameCanvas gameCanvas;

    [SerializeField] [Range(1f, 5f)] float rayDistance = 5f;
    LayerMask keyLayerMask, doorLayerMask;

    GameObject[] takenKeys = new GameObject[2];
    GameObject sellectedKey;

    bool isInventory = false;
    readonly Vector2 rayCameraCenter = new Vector2(Screen.width / 2, Screen.height / 2);

    #region Awake/Start/Update/FixedUpdate
    void Awake()
    {
        keyLayerMask = LayerMask.GetMask("Key");
        doorLayerMask = LayerMask.GetMask("Door");
    }
    void Start()
    {
        gameCanvas = FindObjectOfType<GameCanvas>();
    }
    void Update()
    {
        TakeKey();
        Inventory();
        UseKey();
    }
    void FixedUpdate()
    {
        
    }
    #endregion

    public void SelectKey(int idCell)
    {
        sellectedKey = takenKeys[idCell];
    }
    void TakeKey()
    {        
        Ray ray = Camera.main.ScreenPointToRay(rayCameraCenter);

        Physics.Raycast(ray, out RaycastHit hitKey, rayDistance, keyLayerMask);
        if (hitKey.collider != null)
        {
            gameCanvas.ImageButton—onfirmActive();
            if (Input.GetKeyDown(keyboardKey—onfirm))
            {         
                for (int idCell = 0; idCell < takenKeys.Length; idCell++)
                {
                    var key = hitKey.transform.gameObject;

                    if (takenKeys[idCell]) continue;
                    takenKeys[idCell] = key;
                    gameCanvas.ImageKey(takenKeys[idCell], idCell);
                    key.SetActive(false);
                    return;                    
                }
            }
        }
        else gameCanvas.ImageButton—onfirmActive(false);
    }
    public void DropKey(int idCell)
    {
        gameCanvas.DropImage(idCell); 
        sellectedKey = null;
        for (int i = 0; i < takenKeys.Length; i++)
        {
            if (idCell != i) continue;
            takenKeys[i].transform.position = transform.position;
            takenKeys[i].SetActive(true);
            takenKeys[i] = null;
        }            
    }
    void DropUseKey()
    {
        for (int i = 0; i < takenKeys.Length; i++)
        {
            if (!takenKeys[i]) continue;
            if (sellectedKey == takenKeys[i])
            {
                gameCanvas.DropImage(i);
                Destroy(takenKeys[i]);
                sellectedKey = null;
                takenKeys[i] = null;
            }
        }
    }
    void UseKey()
    {
        if (sellectedKey != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(rayCameraCenter);

            Physics.Raycast(ray, out RaycastHit hitDoor, rayDistance, doorLayerMask);
            if (hitDoor.collider != null)
            {
                gameCanvas.ImageButton—onfirmActive();
                if (Input.GetKeyDown(keyboardKey—onfirm))
                {
                    var door = hitDoor.transform.GetComponent<DoorsTypes>();
                    var useKeyType = sellectedKey.GetComponent<KeysTypes>().keyType;

                    if ((byte)door.doorType == (byte)useKeyType)
                    {
                        door.CorrectDoor();
                        DropUseKey();
                    }
                    else
                    {
                        door.CorrectDoor(false);
                        gameCanvas.imageUseItem.sprite = null;
                        gameCanvas.imageUseItem.gameObject.SetActive(false);
                        sellectedKey = null;
                    }                   
                }
            }
            else gameCanvas.ImageButton—onfirmActive(false);
        }        
    }
    void Inventory()
    {
        if (Input.GetKeyDown(keyboardKeyInventory) && !isInventory)
        {
            PlayerControl.isCanMove = false;
            isInventory = true;
            Cursor.visible = true;
            gameCanvas.InventoryPanel();
        }
        else if (Input.GetKeyDown(keyboardKeyInventory) && isInventory)
        {
            PlayerControl.isCanMove = true;
            isInventory = false;
            Cursor.visible = false;
            gameCanvas.InventoryPanel(false);
        }
    }   
}
