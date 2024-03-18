using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float eH = 3f;

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
        healthBar.UpdateHealthBar(currentHealth,maxHealth);
        knockback.GetKnockedBack(PlayerMovement.Instance.transform, 15f);
        Debug.Log(currentHealth);
        StartCoroutine(flash.FlashRoutine());
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
