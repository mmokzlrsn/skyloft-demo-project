using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;


        [SerializeField]
        private float speed = 0;
        [SerializeField] 
        private float acceleration = 8f;
        [SerializeField]
        private float maxSpeed = 32f;

        
        float distanceTravelled;

        void Start()
        {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

            
        }

        


        void Update()
        {
            if (pathCreator != null)
            {
                ToGoForward();
            }
        }

        public void ToGoForward()
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
                
            }
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }


        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Collision happened.");
                OnKnockbackPush( );
            }
        }


        public void OnKnockbackPush( )
        {
            Debug.Log("OnKnockbackPush Trigger");
            speed = -20;
             
        }

        



    }
}