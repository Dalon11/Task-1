using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float speedMouse = 2f;

    public static bool isCanMove = true;

    CharacterController controller;
    Transform cameraPlayer;

    Vector2 moveMouse = Vector2.zero;
    #region Start/Update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraPlayer = transform.GetChild(0);
        if (isCanMove) Cursor.visible = false;
    }
    void Update()
    {

        PlayerMove();
        CameraMove();
    }
    #endregion

    #region Player Move
    void PlayerMove()
    {
        if (isCanMove)
        {
            Vector2 Move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime;

            transform.Translate(Vector3.forward * Move.y * speed);
            transform.Translate(Vector3.right * Move.x * speed);
        }
    }
    void CameraMove()
    {
        if (isCanMove)
        {
            Vector2 mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            moveMouse += mouseDirection;

            cameraPlayer.localRotation = Quaternion.AngleAxis(-moveMouse.y * speedMouse, Vector3.right);
            transform.localRotation = Quaternion.AngleAxis(moveMouse.x * speedMouse, Vector3.up);
        }
    }
    #endregion

}

