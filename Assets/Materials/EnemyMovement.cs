using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

  [SerializeField] float moveSpeed = 1f;

  Rigidbody2D rb;
  CapsuleCollider2D bodyCollider;
  BoxCollider2D aheadCollider;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
    bodyCollider = GetComponent<CapsuleCollider2D>();
    aheadCollider = GetComponent<BoxCollider2D>();
  }
  void Update() {
    Move();
  }
  void Move() {
    rb.velocity = new Vector2(moveSpeed * (IsFacingRight() ? 1 : -1), 0);
  }
  // void Turn() {
  //   var isEdgeOfPlatform = !aheadCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
  //   if (!isEdgeOfPlatform) return;

  //   FlipDirection();
  // }
  public void FlipDirection() {
    transform.localScale = new Vector3(IsFacingRight() ? -1f : 1f, 1f, 1f);
  }
  void OnTriggerExit2D(Collider2D other) {
    FlipDirection();
  }
  public bool IsFacingRight() {
    return transform.localScale.x > 0;
  }
}
