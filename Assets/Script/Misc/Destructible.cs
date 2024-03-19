using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
[SerializeField] 
    private Material burned;
    [SerializeField] 
    private float restoreDefaultMatTime = .2f;
    private Material defaultMat;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = spriteRenderer.material;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<FireBallBehavior>()) {
            StartCoroutine(FlashRoutine());
            
        }
    }
    public IEnumerator FlashRoutine() {
        spriteRenderer.material = burned;
        yield return new WaitForSeconds(restoreDefaultMatTime);
        Destroy(gameObject);
    }
}
