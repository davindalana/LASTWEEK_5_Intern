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
    private TrailRenderer tr;

    private PlayerController playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sp;
    private float startingMoveSpeed;
    private bool facingLeft = false;
    private bool isDashing = false;

    private void Awake() {
        playerControls = new PlayerController();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        Instance = this;
    }
    private void Start()
    {
        startingMoveSpeed = speed;
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update() {
        PlayerInput();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    private void FixedUpdate() {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput() {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        anim.SetFloat("moveX", movement.x);
        anim.SetFloat("moveY", movement.y);
    }

    private void Move() {
        rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 ps = Camera.main.WorldToScreenPoint(transform.position);
        if (mouse.x > ps.x) {
            sp.flipX = true;
            facingLeft = false;
        } else {
            sp.flipX = false;
            facingLeft = true;
        }
    }

    private void Dash()
    {
        if(!isDashing)
        {
            isDashing = true;
            speed *= dashSpeed;
            tr.emitting = true;
            StartCoroutine(Dashing());
        }
    }
    private IEnumerator Dashing()
    {
        float dashTime = .2f;
        float dashCD = .25f;
        yield return new WaitForSeconds(dashTime);
        speed = startingMoveSpeed;
        tr.emitting = false;
        yield return new WaitForSeconds(dashCD);
        isDashing = false;
    }
}
