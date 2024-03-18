using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    [SerializeField] private Transform home;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= maxRange && Vector2.Distance(player.transform.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if(Vector2.Distance(player.transform.position, transform.position) >= maxRange)
        {
            GoHome();
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, home.position, speed * Time.deltaTime);
    }
}
