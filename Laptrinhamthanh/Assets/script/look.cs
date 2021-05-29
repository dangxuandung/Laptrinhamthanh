using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    [SerializeField]
    private Transform tran;
    
    float mouseSen = 100, XRotate = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;

        XRotate -= mouseY;
        XRotate = Mathf.Clamp(XRotate, -91f, 90f);

        transform.localRotation = Quaternion.Euler(XRotate, 0f, 0f);
        tran.Rotate(Vector3.up * mouseX);

    }
}
