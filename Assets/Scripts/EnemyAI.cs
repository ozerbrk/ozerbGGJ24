using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Assign the player's Transform in the Inspector
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    [SerializeField] private float fallAndDisappearDuration = 2f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target != null)
        {
            // Set the destination to the player's position
            navMeshAgent.SetDestination(target.position);
            animator.SetBool("Walk", true);

            // Calculate the speed parameter for the animator
            //float speed = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
            //animator.SetFloat("Speed", speed);
        }
    }
    public void HitByBomb()
    {
        // Play the fall and disappear animation
        animator.SetBool("Walk", false);
        

        // Disable NavMeshAgent to stop navigation
        navMeshAgent.enabled = false;

        // Destroy the GameObject after the animation duration
        Destroy(gameObject);
    }
}
