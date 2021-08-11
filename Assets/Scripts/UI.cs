using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject txtWin;
    void Start()
    {
        txtWin = transform.Find("txtWin").gameObject;
    }

    
    void Update()
    {
        
    }
}
