using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public Transform playerBody;
    private float xRotation = 0.0f;

    void Start()
    {
        // 锁定光标到屏幕中心，并隐藏光标
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 旋转角度限制，防止翻转
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 旋转相机
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 旋转玩家身体
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
