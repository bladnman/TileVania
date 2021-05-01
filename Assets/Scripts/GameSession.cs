using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour {

  [SerializeField] int playerLives = 3;
  [SerializeField] float deathDelay = 1.5f;
  [SerializeField] TMP_Text livesLabel;
  [SerializeField] TMP_Text scoreLabel;

  int score = 0;

  void Awake() {
    int numGameSessions = FindObjectsOfType<GameSession>().Length;
    if (numGameSessions > 1) {
      Destroy(gameObject);
    } else {
      DontDestroyOnLoad(gameObject);
    }
  }
  void Start() {
    UpdateLabels();
  }
  void UpdateLabels() {
    livesLabel.text = $"{playerLives}";
    scoreLabel.text = $"{score}";
  }
  public void AddToScore(int amount) {
    score += amount;
    UpdateLabels();
  }
  public void ProcessPlayerDeath() {
    StartCoroutine("DoDeath");
  }
  IEnumerator DoDeath() {
    yield return new WaitForSeconds(deathDelay);

    if (playerLives > 1) {
      TakeLife();
    } else {
      ResetGameSession();
    }
  }
  void ResetGameSession() {
    SceneManager.LoadScene(0);
    Destroy(gameObject);
  }
  private void TakeLife() {

    playerLives--;
    UpdateLabels();

    var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }
}
