using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    Camera _camera;
 
    [SerializeField]
    private float directionSpeed = 10.0f; // adjust this with accelaration? this variable is used for left right movement 

    [SerializeField]
    private UnityEvent onCrash;

    RaycastHit hit;
    Ray ray;

    Vector3 startPos;

    private Animator animator;
     
 

    //[Header("Speed")]
    
     
 


    private float knockbackPower = 3.0f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //roadCollider = GameObject.Find("Road").GetComponent<Collider>();
 
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
     
    public void Movement()
    {
         //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                rotateMotor();
                if (hit.collider.CompareTag("Road"))
                { 
                     
                    //trans.ç.for . righr b 
                    //hit.point - trannsform.position
                    //.trekrar transform . right ile çarp
                    //transform position movement

                    transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(hit.point.x , transform.position.y, hit.point.z), Time.deltaTime * directionSpeed);

                    

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
        if (other.CompareTag("Obstacle"))
        {
            onCrash?.Invoke(); // ?. check for null if not call the function  //null propagation
            Debug.Log("Obstacle Trigger");
            animator.SetTrigger("Knockback");
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
         
    }

    private void rotateMotor()
    {
        Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         
        /*
        if (clickedPosition.x < 0)
        {
            Debug.Log("RightRotateAnim");
            animator.SetBool("LeftLean", false);
            animator.SetBool("RightLean", true);
            Debug.Log("Right");
        }
        else if (clickedPosition.x > 0)
        {
            animator.SetBool("LeftLean", true);
            animator.SetBool("RightLean", false);
            Debug.Log("Left");
        }
        else
            Debug.Log("Middle");
        */
        if (clickedPosition.x < transform.localPosition.x)
        {
            Debug.Log("RightRotateAnim");
            animator.SetBool("LeftLean", false);
            animator.SetBool("RightLean", true);
      
            Debug.Log("Right");
        }
        if (clickedPosition.x > transform.localPosition.x)

        {
            animator.SetBool("LeftLean", true);
            animator.SetBool("RightLean", false);
            Debug.Log("Left");
        }
            


        /*
        if (hit.point.x - transform.position.x < transform.position.x)
        {
            //left rotate anim
            Debug.Log("LeftRotateAnim");
            animator.SetBool("LeftLean", true);
            animator.SetBool("RightLean", false);
        }

        else if (hit.point.x - transform.position.x > transform.position.x)
        {
            //right rotate anim
            Debug.Log("RightRotateAnim");
            animator.SetBool("LeftLean", false);
            animator.SetBool("RightLean", true);
        }
            
        else
        {
            //idle anim
            Debug.Log("IdleAnim");
            animator.SetBool("LeftLean", false);
            animator.SetBool("RightLean", false);
        }
        */
    }





}
