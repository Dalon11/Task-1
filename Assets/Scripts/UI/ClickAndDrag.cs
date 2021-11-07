using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAndDrag : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    PlayerItems playerItems;
    GameCanvas gameCanvas;
    Image imageCell;
    
    Vector3 beginTrandform;
    [SerializeField] float radiusDrop = 140;   

    int idCell;

    #region Awake/Start/Update/FixedUpdate
    void Awake()
    {

    }
    void Start()
    {
        beginTrandform = transform.position;
        gameCanvas = FindObjectOfType<GameCanvas>();
        playerItems = FindObjectOfType<PlayerItems>();
        idCell = int.Parse(name.Remove(0, 4)) - 1;
        imageCell = GetComponent<Image>();
    }
    void Update()
    {

    }
    void FixedUpdate()
    {

    }
    #endregion

    public void OnPointerDown(PointerEventData eventData)
    {
        if (imageCell.sprite)
        {
            gameCanvas.imageUseItem.sprite = imageCell.sprite;     
            gameCanvas.imageUseItem.gameObject.SetActive(true);
        }

    }
    public void OnDrag(PointerEventData eventData)
    {
        if (imageCell.sprite)
        {
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        }        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        var distance = (transform.position - beginTrandform).magnitude;

        if (distance > radiusDrop)
        {           
            playerItems.DropKey(idCell);
        }
        transform.position = beginTrandform;
    } 
}

