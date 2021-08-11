using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask keyLayerMask;

     void Update()
    {
        
    }
    void TakeKey()
    {
        //RaycastHit2D hitKey = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.left, rayDistance, keyLayerMask);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitKey, rayDistance, keyLayerMask);


        if (hitKey.collider != null)
        {
            
        }
    }
}
