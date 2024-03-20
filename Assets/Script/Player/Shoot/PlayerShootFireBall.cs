using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootFireBall : PlayerShoot
{
    PlayerShoot playerShoot;

    void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)&&playerShoot.isAttacking)
            {
                AudioManager.audio.PlaySound(1);
                playerShoot.Shoot();
                playerShoot.StartCoroutine(playerShoot.ShootCD());
            }
    }
}
