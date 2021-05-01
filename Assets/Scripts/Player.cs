using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  [SerializeField] float runSpeed = 5f;
  [SerializeField] float jumpSpeed = 5f;
  [SerializeField] float climbSpeed = 5f;
  [SerializeField] Vector2 deathKick = new Vector2(100f, 100f);

  bool isAlive = true;
  float initialGravity;

  Animator animator;
  Rigidbody2D rb;
  CapsuleCollider2D bodyCollider;
  BoxCollider2D feetCollider;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    bodyCollider = GetComponent<CapsuleCollider2D>();
    feetCollider = GetComponent<BoxCollider2D>();

    initialGravity = rb.gravityScale;
  }
  void Update() {

    if (!isAlive) return;
    Die();
    Jump();
    Run();
    ClimbLadder();
  }
  void Run() {
    var isRunning = false;
    var controlThrow = Input.GetAxis("Horizontal");
    if (controlThrow != 0) {
      rb.velocity = new Vector2(controlThrow * runSpeed, rb.velocity.y);
      isRunning = Mathf.Abs(rb.velocity.x) > 0.1;

      // since we're moving, let's set our facing
      FlipSprite();
    }
    animator.SetBool("isRunning", isRunning);
  }
  void ClimbLadder() {

    var isTouchingLadder = feetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"));
    if (!isTouchingLadder) {
      animator.SetBool("isClimbing", false);
      rb.gravityScale = initialGravity;
      return;
    }

    var controlThrow = Input.GetAxis("Vertical");
    rb.velocity = new Vector2(rb.velocity.x, controlThrow * climbSpeed);
    rb.gravityScale = 0f;

    var isMoving = Mathf.Abs(rb.velocity.y) > 0.1;
    animator.SetBool("isClimbing", isMoving);

  }
  void Jump() {
    var isTouchingGround = feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    if (!isTouchingGround) return;

    if (Input.GetButtonDown("Jump")) {
      var addedVelocity = new Vector2(0, jumpSpeed);
      rb.velocity += addedVelocity;
    }
  }
  void FlipSprite() {
    transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1f, 1f);
  }
  void Die() {
    if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards"))) {
      isAlive = false;
      animator.SetTrigger("Die");
      rb.velocity = deathKick;

      var gameSession = FindObjectOfType<GameSession>();
      gameSession.ProcessPlayerDeath();
    }
  }
}
