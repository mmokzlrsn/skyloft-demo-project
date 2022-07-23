using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(0, 0, player.transform.position.z);
    }
}
