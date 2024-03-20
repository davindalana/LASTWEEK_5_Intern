using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject shootBall;
    public Transform shootPoint;
    public bool isAttacking = true;

    void Update()
    {
        Shoot();
    }
    public void Shoot()
    { 
        if (Input.GetKeyDown(KeyCode.Mouse0)&&isAttacking)
        {
            Debug.Log(shootPoint.position);
            Instantiate(shootBall, shootPoint.position, transform.rotation);
            StartCoroutine(ShootCD());
        }
    }
    public IEnumerator ShootCD()
    {
        isAttacking = false;
        yield return new WaitForSeconds(.5f);
        isAttacking = true;
    }
}
