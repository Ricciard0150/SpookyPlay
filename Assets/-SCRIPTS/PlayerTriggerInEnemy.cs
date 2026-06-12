using UnityEngine;

public class PlayerTriggerInEnemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
 
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsPunch", true);
            animator.SetBool("IsChasing", true);
            animator.SetBool("IsPatroling", false);
            animator.SetBool("IsIdle", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsPunch", false);
            animator.SetBool("IsChasing", false);
            animator.SetBool("IsPatroling", true);
            animator.SetBool("IsIdle", false);
        }
    }
}

