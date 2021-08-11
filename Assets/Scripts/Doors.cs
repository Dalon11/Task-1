using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(Renderer))]
public class Doors : MonoBehaviour
{
    enum  DoorLock : byte 
    { 
        red, 
        green, 
        blue
    } 

    [SerializeField] DoorLock doorLock;
 
    
    void Start()
    {
        DoorColors();
    }

    void DoorColors()
    {
        Material colorDoor = gameObject.GetComponent<Renderer>().material;
        
        switch (doorLock)
        {
            case DoorLock.red:
                colorDoor.color = Color.red;                
                break;
            case DoorLock.green:
                colorDoor.color = Color.green;
                break;
            case DoorLock.blue:
                colorDoor.color = Color.blue;
                break;          
        }
    }
}
