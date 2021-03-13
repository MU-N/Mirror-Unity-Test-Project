using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    void HandleMovement()
    {
        if (isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical * 0.1f, 0);
            transform.position = transform.position + movement;
        }

    }



    private void Update()
    {
        HandleMovement();
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Sending hello to Server!");
            SayHello();
        }
        
    }

    [Command]
    void  SayHello()
    {
        Debug.Log("Sens hello");
    }

    [ClientRpc]
    void TooHigh()
    {
        Debug.Log("Too high!");
    }

    [TargetRpc]
    void ReplyHola()
    {
        Debug.Log("Received Hola from Server!");
    }
}
