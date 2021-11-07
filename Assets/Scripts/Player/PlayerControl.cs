using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(PlayerItems))]

public class PlayerControl : MonoBehaviour
{
    public static bool isCanMove = true;

    Transform cameraPlayer;

    [SerializeField] float speed = 10f;
    [SerializeField] float speedMouse = 2f;
    
    readonly float cameraMinMaxAngle = 30;
    Vector2 moveMouse = Vector2.zero;

    #region Awake/Start/Update/FixedUpdate
    void Awake()
    {

    }
    void Start()
    {
        if (isCanMove) Cursor.visible = false;
        cameraPlayer = transform.GetChild(0);
    }
    void Update()
    {
        Move();
    }
    void FixedUpdate()
    {

    }
    #endregion

    void Move()
    {
        if (isCanMove)
        {
            MovePlayer();
            MoveCamera();
        }
    }
    void MovePlayer()
    {       
        var Move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime;

        transform.Translate(Vector3.forward * Move.y * speed);
        transform.Translate(Vector3.right * Move.x * speed);        
    }
    void MoveCamera()
    {        
        var mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        moveMouse = new Vector2(moveMouse.x + mouseDirection.x, Mathf.Clamp(moveMouse.y + mouseDirection.y, -cameraMinMaxAngle, cameraMinMaxAngle));
        cameraPlayer.localRotation = Quaternion.AngleAxis(-moveMouse.y * speedMouse, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(moveMouse.x * speedMouse, Vector3.up);
    }

}

