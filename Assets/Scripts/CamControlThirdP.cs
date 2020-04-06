using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControlThirdP : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
    
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }

        mouseX += Input.GetAxis("Mouse X") * RotationSpeed * Time.timeScale;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed * Time.timeScale;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);
    }
}
