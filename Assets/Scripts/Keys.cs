using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(Renderer))]
public class Keys : MonoBehaviour
{
    enum Key : byte 
    {   
        red, 
        green, 
        blue 
    }

    [SerializeField] Key key;

    [SerializeField] Texture[] keysTexture;

    void Update()
    {
        KeysTexture();
    }

    void KeysTexture()
    {
        Material keys = gameObject.GetComponent<Renderer>().material;
       
        switch (key)
        {
            case Key.red:
                keys.SetTexture("_MainTex", keysTexture[0]);
                break;
            case Key.green:
                keys.SetTexture("_MainTex", keysTexture[1]);
                break;
            case Key.blue:
                keys.SetTexture("_MainTex", keysTexture[2]);
                break;            
        }
    }
}
