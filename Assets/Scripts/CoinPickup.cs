using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

  [SerializeField] AudioClip coinPickupSFX;
  [SerializeField] int value = 100;

  bool isCollected = false;

  private void OnTriggerEnter2D(Collider2D other) {
    if (isCollected) return;
    isCollected = true;

    AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
    Destroy(gameObject);

    var gameSession = FindObjectOfType<GameSession>();
    gameSession.AddToScore(value);
  }
}
