using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecher_camera : MonoBehaviour
{
    /*// Start is called before the first frame update
    [SerializeField] private float sensx;
    [SerializeField] private float sensy;

    Camera cam;

    float mousex;
    float mousey;

    float multiplier = 2.05f;

    float xRotation;
    float yRotation;

    private void Start(){

        cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update(){

        MyInput();

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0 , 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);

    }

    void MyInput(){

        mousex = Input.GetAxisRaw("Mouse X");
        mousey = Input.GetAxisRaw("Mouse Y");

        yRotation += mousex * sensx * multiplier;
        xRotation -= mousey * sensy * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
    }
*/
}
