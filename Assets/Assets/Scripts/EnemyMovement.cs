using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.y < -50)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(1); // Damage via PlayerHealth
                }
            }
            Destroy(gameObject);
        }
    }
}