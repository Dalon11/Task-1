using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(Renderer))]
public class Doors : MonoBehaviour
{
    public static int totalGreenDoor =0;
    public enum  DoorLock : byte 
    { 
        red, 
        green, 
        blue
    }

    public DoorLock doorLock;

    Material colorDoor;

    void Start()
    {
        colorDoor = gameObject.GetComponent<Renderer>().material; 
    }

    public void DoorColors(bool yes = true)
    {
        if (yes)
        {
            totalGreenDoor++;
            colorDoor.color = Color.green;
            GetComponent<Collider>().enabled=false;
        }
        else StartCoroutine(RedDoor());
    }

    IEnumerator RedDoor()
    {
        colorDoor.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        colorDoor.color = Color.white;
    }

}

