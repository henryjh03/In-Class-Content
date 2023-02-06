using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //variable for player movement speed
    [SerializeField] float speed = 2f;

    //variable for player turning speed
    [SerializeField] float turnSpeed = 10f;

    //variable for player jumping speed
    [SerializeField] float jumpSpeed = 10f;

    private Rigidbody rb;
    private bool onFloor = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onFloor = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onFloor = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Foward & Back
        if(Input.GetKey("w"))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey("s"))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
        
        // Left & Right
        if(Input.GetKey("a"))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        // Turn
        /*
        if(Input.GetKey("q"))
        {
            transform.Rotate(-transform.up * Time.deltaTime * turnSpeed);
        }
        if(Input.GetKey("e"))
        {
            transform.Rotate(transform.up * Time.deltaTime * turnSpeed);
        }
        */

        // Jump
        if(Input.GetKeyDown("space") && onFloor == true)
        {
            rb.AddForce(transform.up * jumpSpeed);
        }
    }
}
