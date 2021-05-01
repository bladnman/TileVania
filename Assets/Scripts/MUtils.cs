using UnityEngine;

public static class MUtils {
  public static int Sum(int number1, int number2) {
    return number1 + number2;
  }
  public static Vector2 AddV(Vector2 first, Vector2 second) {
    return new Vector2(first.x + second.x, first.y + second.y);
  }
  public static Vector3 AddV(Vector3 first, Vector2 second) {
    return new Vector3(first.x + second.x, first.y + second.y, first.z);
  }
  public static Vector3 AddV(Vector2 first, Vector3 second) {
    return new Vector3(first.x + second.x, first.y + second.y, second.z);
  }
  public static Vector3 AddV(Vector3 first, Vector3 second) {
    return new Vector3(first.x + second.x, first.y + second.y, first.z + second.z);
  }
}
