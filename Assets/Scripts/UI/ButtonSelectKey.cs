using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectKey : MonoBehaviour
{
    [SerializeField] GameCanvas gameCanvas;
    [SerializeField] PlayerItems playerItems;

    public int idCell;

    #region Awake/Start/Update/FixedUpdate
    void Awake()
    {

    }
    void Start()
    {
        gameCanvas = FindObjectOfType<GameCanvas>();
        playerItems = FindObjectOfType<PlayerItems>();
    }
    void Update()
    {

    }
    void FixedUpdate()
    {

    }
    #endregion

    public void SelectKey()
    {
     
    }
}
