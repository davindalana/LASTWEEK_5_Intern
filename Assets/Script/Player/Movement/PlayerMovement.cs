using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } }
    public static PlayerMovement Instance;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float dashSpeed = 4f;
    [SerializeField]

    private PlayerController playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sp;
    private float startingMoveSpeed;
    private bool facingLeft = false;
    private bool isDashing = false;
    private KnockBack knockBack;
    public AudioSource footAudio;

    private void Awake()
    {
        playerControls = new PlayerController();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        knockBack = GetComponent<KnockBack>();
        Instance = this;
    }
    private void Start()
    {
        startingMoveSpeed = speed;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            footAudio.enabled = true;
        }
        else
        {
            footAudio.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        anim.SetFloat("moveX", movement.x);
        anim.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        if (knockBack.gettingKnockedBack) { return; }
        rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 ps = Camera.main.WorldToScreenPoint(transform.position);
        if (mouse.x > ps.x)
        {
            sp.flipX = true;
            facingLeft = false;
        }
        else
        {
            sp.flipX = false;
            facingLeft = true;
        }
    }

    private void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            speed *= dashSpeed;
            AudioManager.audio.PlaySound(0);
            StartCoroutine(Dashing());
        }
    }
    private IEnumerator Dashing()
    {
        float dashTime = .2f;
        float dashCD = .25f;
        yield return new WaitForSeconds(dashTime);
        speed = startingMoveSpeed;
        yield return new WaitForSeconds(dashCD);
        isDashing = false;
    }
}
