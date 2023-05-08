using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //float mouse sensitivity 
    [SerializeField] private float sens;

    //vertical clamp 
    [SerializeField] private float clamp;

    //reference to the camera 
    [SerializeField] private GameObject cam;
    //reference to the player object 
    [SerializeField] private GameObject player;

    //float for the x rotation 
    private float rotX;
    //float for the y rotation 
    private float rotY; 

    // Start is called before the first frame update
    void Start()
    {
        //assign the x and y rotation of the camera to a vector 3
        Vector3 rot = transform.localRotation.eulerAngles;

        //set rotX and rotY to be equal to rotation of camera 
        rotX = rot.x;
        rotY = rot.y;
    }

    // Update is called once per frame
    void Update()
    {
        //get the mouse x and the mouse y movement and assign to floats
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //modify rotX / Y by the mouse x and y, multiplied by the sensitivity and time.deltatime
        rotX += mouseX * sens * Time.deltaTime;
        rotY += mouseY * sens * Time.deltaTime;

        //apply clamping on the x axis 
        rotY = Mathf.Clamp(rotY, -clamp, clamp);

        //create a local quaternion with the rotX / rotY values
        Quaternion localRot = Quaternion.Euler(-rotY, rotX, 0f);
        Quaternion bodyRot = Quaternion.Euler(0f, rotX, 0f);

        //update the transform.rotation
        transform.rotation = localRot; 
        player.transform.rotation = bodyRot; 
    }
}
