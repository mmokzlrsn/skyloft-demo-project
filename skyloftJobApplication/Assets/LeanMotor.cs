using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanMotor : MonoBehaviour
{
     
    Camera _camera;
    Collider roadCollider;

    [SerializeField]
    private float directionSpeed = 10.0f; // adjust this with accelaration? this variable is used for left right movement 


    RaycastHit hit;
    Ray ray;



    [SerializeField]
    private Vector3 _rotation;
    [SerializeField]
    private float rotateSpeed = 80f;



    //[Header("Speed")]

    [SerializeField]
    private float rotation = 8f;
    
    [SerializeField]
    private float maxRotationAngle = 32;


    //private float knockbackPower = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //roadCollider = GameObject.Find("Road").GetComponent<Collider>();



    }

    // Update is called once per frame
    void Update()
    {
        Lean();
    }


    public void Lean()
    {
        if (Input.GetMouseButton(0))
        {
            ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Road"))
                {

                    /*
                    transform rotation movement Make it max Rotate scale then apply it to both sides using only - sign Create speed variable according to the accelaration? 
                    //transform.Rotate(_rotation * 2.0f * Time.deltaTime);


                    //transform position movement
                    transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(hit.point.x, transform.position.y, transform.position.z), Time.deltaTime * directionSpeed);
                    //transform.rotation = Vector3.RotateTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(hit.point.x, transform.position.y, transform.position.z), Time.deltaTime * directionSpeed);

                    transform.rotation = Vector3.RotateTowards(transform.forward, new Vector3(transform.rotation.x, transform.rotation.y, hit.point.z), Time.deltaTime * rotateSpeed, 0.0f);

                    */
                    Lean2();

                    Debug.Log("You clicked SafeArea");


                }


            }


        }
    }

    public void Lean2()
    {

        // Determine which direction to rotate towards
        Vector3 targetDirection = hit.point - transform.position;
        //Vector3 targetDirection = new Vector3(transform.position.x, transform.position.y, hit.point.z - transform.position.z);

        // The step size is equal to speed times frame time.
        float singleStep = rotateSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
       

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        Debug.Log("Lean2 is executed");
    }
}
