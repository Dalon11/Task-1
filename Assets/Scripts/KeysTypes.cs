using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(Renderer))]
public class KeysTypes : MonoBehaviour
{
    [SerializeField] Texture[] keysTexture = new Texture[3];

    public enum KeyType : byte 
    {   
        red, 
        green, 
        blue 
    }
    public KeyType keyType;

    #region Awake/Start/Update/FixedUpdate
    void Awake()
    {

    }
    void Start()
    {

    }
    void Update()
    {
        KeysTexture();
    }
    void FixedUpdate()
    {

    }
    #endregion

    void KeysTexture()
    {
        var keysMaterial = gameObject.GetComponent<Renderer>().material;
       
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
