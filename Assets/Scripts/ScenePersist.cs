using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {

  int sceneIndex;

  void Awake() {
    int numOfMe = FindObjectsOfType<ScenePersist>().Length;
    if (numOfMe > 1) {
      Destroy(gameObject);
    } else {
      DontDestroyOnLoad(gameObject);
    }
  }
  void Start() {
    sceneIndex = SceneManager.GetActiveScene().buildIndex;
  }
  private void Update() {
    if (sceneIndex != SceneManager.GetActiveScene().buildIndex) {
      Destroy(gameObject);
    }
  }
}
