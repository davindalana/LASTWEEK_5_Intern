
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float eH = 40f;

    private float maxHealth;
    private float currentHealth;

    [SerializeField]
    private FloatingHealthBar healthBar;

    private KnockBack knockback;
    private Flash flash;

    private void Start()
    {
        currentHealth = eH;
        maxHealth = eH;
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        knockback = GetComponent<KnockBack>();
        flash = GetComponent<Flash>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth<=0)
        {
            DetectDeath();
        }
        healthBar.UpdateHealthBar(currentHealth,maxHealth);
        Debug.Log(currentHealth);
        StartCoroutine(flash.FlashRoutine());
    }

    public void KnockBack()
    {
        knockback.GetKnockedBack(PlayerMovement.Instance.transform, 15f);
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
