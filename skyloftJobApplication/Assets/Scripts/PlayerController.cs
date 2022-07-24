using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    Camera _camera;
    Collider roadCollider;

    [SerializeField]
    private float directionSpeed = 10.0f; // adjust this with accelaration? this variable is used for left right movement 


    RaycastHit hit;
    Ray ray;

    Vector3 startPos;

    [SerializeField]
    private Vector3 _rotation;

    private float zStartPos;

    //[Header("Speed")]
    
    private float acceleration = 8f;
    float maxSpeed = 32;
    public float speed = 0;


    private float knockbackPower = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        roadCollider = GameObject.Find("Road").GetComponent<Collider>();
         
        zStartPos = transform.position.z;

        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        

        Movement();
    }

    public void ToGoForward()
    {
        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);

    }

    public void Movement()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Road"))
                {

                    //transform rotation movement Make it max Rotate scale then apply it to both sides using only - sign Create speed variable according to the accelaration? 
                    //transform.Rotate(_rotation * 2.0f * Time.deltaTime);
                     

                    //transform position movement
                    transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(hit.point.x, transform.position.y, transform.position.z), Time.deltaTime * directionSpeed);
                    //transform.rotation = Vector3.RotateTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(hit.point.x, transform.position.y, transform.position.z), Time.deltaTime * directionSpeed);

                    Debug.Log("You clicked SafeArea");


                }


            }

             
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeadZone"))
        {
            transform.position = startPos;
            Debug.Log("You are dead ");
            
        }

        if(other.CompareTag("FinishLine"))
        {
            transform.position = startPos;
            Debug.Log("You Won ");
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = collision.transform.position - transform.position;

        if (Vector3.Dot(transform.forward, direction) > 0)
        {
            print("Back");
        }
        if (Vector3.Dot(transform.forward, direction) < 0)
        {
            print("Front");
        }
        if (Vector3.Dot(transform.forward, direction) == 0)
        {
            print("Side");
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            knockbackPush(collision);
            

        }
    }

    private void knockbackPush(Collision collision)
    {
        Rigidbody playerRB = gameObject.GetComponent<Rigidbody>();

        Vector3 knockback = transform.position - collision.gameObject.transform.position;

        //create knockback types according to the speed
        playerRB.AddForce(knockback * knockbackPower , ForceMode.Impulse);
        speed = 0;

        Debug.Log("OnCollisionEnter" + speed);
    }

    





}
