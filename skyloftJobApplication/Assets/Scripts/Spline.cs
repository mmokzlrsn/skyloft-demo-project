using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    [SerializeField]
    private GameObject[] roadPoints;
   

    void Start()
    {
        roadPoints = GameObject.FindGameObjectsWithTag("Road");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
