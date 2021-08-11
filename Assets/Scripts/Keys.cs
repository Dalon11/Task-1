using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(Renderer))]
public class Keys : MonoBehaviour
{
    public enum KeyType : byte 
    {   
        red, 
        green, 
        blue 
    }

    public KeyType keyType;

    public Texture[] keysTexture;

    void Update()
    {
        KeysTexture();
    }

    void KeysTexture()
    {
        Material keysMaterial = gameObject.GetComponent<Renderer>().material;
       
        switch (keyType)
        {
            case KeyType.red:
                keysMaterial.SetTexture("_MainTex", keysTexture[0]);
                break;
            case KeyType.green:
                keysMaterial.SetTexture("_MainTex", keysTexture[1]);
                break;
            case KeyType.blue:
                keysMaterial.SetTexture("_MainTex", keysTexture[2]);
                break;            
        }
    }
}
