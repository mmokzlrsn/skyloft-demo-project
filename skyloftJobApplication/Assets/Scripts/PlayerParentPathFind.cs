using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParentPathFind : MonoBehaviour
{

    private Vector3 startPos;

    public Transform motorcycle;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + motorcycle.position;
    }
}
