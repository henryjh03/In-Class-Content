using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddles : MonoBehaviour
{
    //variable for paddle speed 
    [SerializeField] float speed;

    // variable determinig if this is left or right paddle
    [SerializeField] bool isLeftPaddle;

    //variable for rigid body 
    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        //automatically assign the rigidbody with trygetcomponent
        if(!TryGetComponent<Rigidbody>(out rbody))
        {
            //disable the object if ti has no rigid body
            Debug.LogError("There is no rigidbody attached to this paddle!");
            gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if this is the left paddle
        if (isLeftPaddle)
        {
            //check if the player is pressing W
            if (Input.GetAxisRaw("VerticalLeft") > 0)
            {
                //move paddle north if they are pressing w
                rbody.AddForce(0, 0, speed);
            }
            //check if player is pressing S
            else if (Input.GetAxisRaw("VerticalLeft") < 0)
            {
                //move paddle south if they are pressing s
                rbody.AddForce(0, 0, -speed);
            }
            else
            {
                rbody.velocity = Vector3.zero;
            }

        }
        else
        {
            //check if the player is pressing up arrow key
            if (Input.GetAxisRaw("VerticalRight") > 0)
            {
                //move paddle north if they are pressing up arrow key
                rbody.AddForce(0, 0, speed);
            }
            //check if player is pressing down arrow key
            else if (Input.GetAxisRaw("VerticalRight") < 0)
            {
                //move paddle south if they are pressing down arrow key
                rbody.AddForce(0, 0, -speed);
            }
            else
            {
                rbody.velocity = Vector3.zero;
            }
        }
    }
}
