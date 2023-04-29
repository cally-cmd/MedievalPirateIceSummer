using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

  public static GameManager Instance {get; private set;}

  public GameObject dialogBox;
  public TextMeshProUGUI dialogText;

  void Awake() {
    if (Instance == null) {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
    }
  }

  void Start() {
    dialogBox.SetActive(false);
  }

  public void DialogShow(string s) {
    dialogBox.SetActive(true);
    StopAllCoroutines();
    StartCoroutine(TypeText(s));
  }

  IEnumerator TypeText(string s) {
    dialogText.text = "";
    foreach (char c in s.ToCharArray()) {
      dialogText.text += c;
      yield return new WaitForSeconds(0.05f);
    }
    yield return new WaitForSeconds(5f);
    DialogHide();
  }

  public void DialogHide() {
    dialogBox.SetActive(false);
  }
}
