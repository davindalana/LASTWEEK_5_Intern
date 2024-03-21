
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private float knockBackAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;
    private bool canTakeDamage = true;
    private KnockBack knockBack;
    private Flash flash;
    public GameObject[] healthUI;
    

    public void Awake()
    {
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }

    public void TakeDamage()
    {
        AudioManager.audio.PlaySound(3);
        canTakeDamage = false;
        Debug.Log(health);
        health--;
        if (health <= 0)
        {
            health = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            print("Player Death");
        }
        healthUI[health].SetActive(false);
        StartCoroutine(DamageRecoveryTime());
    }

    
    private void OnCollisionStay2D(Collision2D other)
    {
        EnemyHealth enemy = other.gameObject.GetComponent<EnemyHealth>();
        if (enemy && canTakeDamage)
        {
            TakeDamage();
            knockBack.GetKnockedBack(other.gameObject.transform, knockBackAmount);
            StartCoroutine(flash.FlashRoutine());
        }
    }
    private IEnumerator DamageRecoveryTime()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

}
