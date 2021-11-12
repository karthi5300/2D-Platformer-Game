using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector3 tempPosition;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        tempPosition = transform.position;  //get camera's current position

        tempPosition.x = player.position.x; //get player's x position
        tempPosition.y = player.position.y; //get player's y position

        transform.position = tempPosition;  //set it to camera's position

    }
}
