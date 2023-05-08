using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script will handle plaer movement using WASD on keyboard, left stick on
 * controller or the on screen up/down/left/right buttons
 * The player can only move to the objects with the NodeScript on them
 * When an input is detected we check if there is a node in that direction,
 * and if there is we assign that node as the player's target destination 
 */

public class PlayerMovement : MonoBehaviour
{
    //variable for the target node
    [SerializeField] private GameObject playerTarget;

    //ables for the player speed
    [SerializeField] private float playerSpeed;
    [SerializeField] private float stoppingDistance;

    private void Update()
    {
        if(playerTarget != null)
        {
            if(Vector3.Distance(transform.position, playerTarget.transform.position) > stoppingDistance)
            {
                //player will move towards the target
                transform.position = Vector3.Lerp(transform.position, playerTarget.transform.position, playerSpeed * Time.deltaTime);
            }
        }
        PlayerMoveInput();
    }

    public void PlayerMoveInput()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            Debug.Log("input detected");
            CheckForNode(-Vector3.right);
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            CheckForNode(Vector3.right);
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            CheckForNode(-Vector3.forward);
        }
        else if(Input.GetAxis("Vertical") > 0)
        {
            CheckForNode(Vector3.forward);
        }
    }

    public void PlayerMouseInput(int direction)
    {
        /*take in int to determine direction
        * 0 = North
        * 1 = East
        * 2 = South
        * 3 = West
        */

        switch (direction)
        {
            case 0:
                CheckForNode(Vector3.forward);
                return;
            case 1:
                CheckForNode(Vector3.right);
                return;
            case 2:
                CheckForNode(-Vector3.forward);
                return;
            case 3:
                CheckForNode(-Vector3.right);
                return;
        }
    }

    public void CheckForNode(Vector3 checkDirection)
    {
        Vector3 direction = Vector3.zero;

        RaycastHit hit;
        NodeScrpit node;

        if(Physics.Raycast(transform.position, checkDirection, out hit, 50f))
        {
            if(hit.collider.TryGetComponent<NodeScrpit>(out node))
            {
                PlayerMoveToNode(node.gameObject);
            }
        }
        else
        {
            Debug.Log("no valid target");
        }
    }

    public void PlayerMoveToNode(GameObject target)
    {
        playerTarget = target;
    }
}
