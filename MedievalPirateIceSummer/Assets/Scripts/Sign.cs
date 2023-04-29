using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {
  
  public string text;

  void Start() {
    print(text);
    GameManager.Instance.DialogShow("This is a test!");
    GameManager.Instance.DialogHide();
  }

  void OnTriggerEnter2D(Collider2D col) {
    print("Enter sign!");
    if (col.gameObject.CompareTag("Player")) {
      GameManager.Instance.DialogShow(text);
    }
  }

  void OnTriggerExit2D(Collider2D col) {
    print("Exit sign!");
    if (col.gameObject.CompareTag("Player")) {
      GameManager.Instance.DialogHide();
    }
  }
}
