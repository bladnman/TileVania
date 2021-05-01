using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour {
  [SerializeField] float scrollRate = 1f;

  void Update() {
    var moveDelta = scrollRate * Time.deltaTime;
    transform.Translate(new Vector2(0f, moveDelta));
  }
}
