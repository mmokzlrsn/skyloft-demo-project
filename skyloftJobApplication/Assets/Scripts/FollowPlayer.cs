using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private float zCameraOffset = -5.0f;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z );

        //transform.LookAt(player.transform);
    }
}
