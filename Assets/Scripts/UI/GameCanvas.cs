using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameCanvas : MonoBehaviour
{
    [SerializeField] GameObject txtWin;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject imageButton—onfirm;    
    public Image imageUseItem;
    [Space]
    [SerializeField] Image[] imageTakenKeys = new Image[2];
    [SerializeField] Sprite[] keySprites = new Sprite[3];

    #region Awake/Start/Update/FixedUpdate
    void Awake()
    {

    }
    void Start()
    {

    }
    void Update()
    {
        Win();
    }
    void FixedUpdate()
    {

    }
    #endregion
    
    public void ImageKey(GameObject key, int idCell)
    {
        int keySpriteID = (int)key.GetComponent<KeysTypes>().keyType;

        imageTakenKeys[idCell].sprite = keySprites[keySpriteID]; 
    }  
    public void DropImage(int idCell)
    {
        imageUseItem.sprite = null;
        imageUseItem.gameObject.SetActive(false);
        for (int i = 0; i < imageTakenKeys.Length; i++)
        {
            if (idCell != i) continue;       
            imageTakenKeys[i].sprite = null;
        }       
    }
    public void ImageButton—onfirmActive(bool active = true)
    {
        imageButton—onfirm.SetActive(active);
    }
    public void InventoryPanel(bool active = true)
    {
        inventoryPanel.SetActive(active);
    }     
    void Win()
    {
        if (DoorsTypes.totalGreenDoor == 3) txtWin.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerControl.isCanMove = true;
        DoorsTypes.totalGreenDoor = 0;
    }
}
