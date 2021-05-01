using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {
  [SerializeField] float levelTransitionTime = 1f;
  [SerializeField] float levelExitSlowMoFactor = 0.2f;

  private void OnTriggerEnter2D(Collider2D other) {
    StartCoroutine("LoadNextScene");
  }
  IEnumerator LoadNextScene() {
    Time.timeScale = levelExitSlowMoFactor; // slow-mo at level end
    yield return new WaitForSeconds(levelTransitionTime);
    Time.timeScale = 1.0f;

    var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    // if (currentSceneIndex == SceneManager.sceneCount - 1) {
    //   SceneManager.LoadScene(currentSceneIndex + 1);

    // } else {

    // }
    SceneManager.LoadScene(currentSceneIndex + 1);

  }
}
