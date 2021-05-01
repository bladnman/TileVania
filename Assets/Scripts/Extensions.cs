using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtensions {
  public static Vector3 AddV(this Vector3 first, Vector3 second) {
    return new Vector3(first.x + second.x, first.y + second.y, first.z + second.z);
  }
  public static Vector3 AddV(this Vector3 first, Vector2 second) {
    return new Vector3(first.x + second.x, first.y + second.y, first.z);
  }
  public static Vector2 AddV(this Vector2 first, Vector3 second) {
    return new Vector2(first.x + second.x, first.y + second.y);
  }
  public static Vector2 AddV(this Vector2 first, Vector2 second) {
    return new Vector2(first.x + second.x, first.y + second.y);
  }
}
