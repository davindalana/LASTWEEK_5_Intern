using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallBehaviour : MonoBehaviour
{
    [SerializeField]
    public float speed, destroyTime;
    [SerializeField]
    private int damageAmount = 1;

    void Awake()
    {
        Destroy(gameObject, destroyTime);
     

    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (other.CompareTag("Beast"))
            {
            enemyHealth.TakeDamage(2*damageAmount);
            }
            if (other.CompareTag("Humanoid"))
            {
            enemyHealth.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
        }
        if (other.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.GetComponent<Destructible>())
        {
            Destroy(gameObject);
        }
    }
}
