using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAnaDrop : MonoBehaviour, IDragHandler, IDropHandler
{
    [SerializeField] Vector3 beginTrandform;
    [SerializeField] float radiusDrop = 250f;
    [SerializeField] UI gameCanvas;
    [SerializeField] int item;

    void Start()
    {
        beginTrandform = transform.position;
        gameCanvas = FindObjectOfType<UI>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var distance = (transform.position - beginTrandform).magnitude;
        if (distance > radiusDrop)
        {
            transform.position = beginTrandform;
            gameCanvas.Drop(item);
            
        }
        else transform.position = beginTrandform;
    }
}

