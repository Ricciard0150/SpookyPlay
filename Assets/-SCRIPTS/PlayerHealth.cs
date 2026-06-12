using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int playerLife = 3;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Punch"))
        {
            playerLife--;
        }
        if (playerLife <= 0)
            OnDeath();
    }
    private void OnDeath()
    {
        
    }
}
