using UnityEngine;

public class PlayerShootWaterBall : PlayerShoot
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
                AudioManager.audio.PlaySound(2);
                playerShoot.Shoot();
                playerShoot.StartCoroutine(playerShoot.ShootCD());
            }
    }
}
