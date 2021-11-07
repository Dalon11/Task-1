using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(Renderer))]
public class DoorsTypes : MonoBehaviour
{
    public static int totalGreenDoor = 0;

    public DoorType doorType;
    Material colorDoor;
    public enum  DoorType : byte 
    { 
        red, 
        green, 
        blue
    }

    void Start()
    {
        colorDoor = gameObject.GetComponent<Renderer>().material; 
    }

    public void CorrectDoor(bool correct = true)
    {
        if (correct)
        {
            totalGreenDoor++;
            colorDoor.color = Color.green;
            GetComponent<BoxCollider>().enabled=false;
        }
        else StartCoroutine(WrongDoor());
    }
    IEnumerator WrongDoor()
    {
        colorDoor.color = Color.red;
        yield return new WaitForSeconds(0.8f);
        colorDoor.color = Color.white;
    }

}

