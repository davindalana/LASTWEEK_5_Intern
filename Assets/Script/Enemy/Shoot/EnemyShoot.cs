using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private Transform laserPos;
    [SerializeField] private float timer;
    [SerializeField] private float range;

    private GameObject player;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < range)
        {
            timer += Time.deltaTime;
        }

        if (timer > 2)
        {
            timer = 0;
            ShootEnemy();
        }
    }

    private void ShootEnemy()
    {
        Instantiate(laser, laserPos.position, Quaternion.identity);

    }
}
