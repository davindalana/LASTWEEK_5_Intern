using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject shootBall;
    public Transform shootPoint;
    private bool isAttacking = true;

    void Update()
    {
        Shoot();
    }
    void Shoot()
    { 
        if (Input.GetKeyDown(KeyCode.Mouse0)&&isAttacking)
        {
            Debug.Log(shootPoint.position);
            Instantiate(shootBall, shootPoint.position, transform.rotation);
            StartCoroutine(ShootCD());
        }
    }
    IEnumerator ShootCD()
    {
        isAttacking = false;
        yield return new WaitForSeconds(1);
        isAttacking = true;
    }
}
