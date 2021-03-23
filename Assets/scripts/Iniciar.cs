using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Iniciar : MonoBehaviour
{
    // Start is called before the first frame update
    public void start() {
        StartCoroutine(NextConfig());
    }

    public void back() {
        StartCoroutine(BackHomeScreen());
    }

   IEnumerator NextConfig() {
    SceneManager.LoadScene("Menu");
    yield return 0;
  }

     IEnumerator BackHomeScreen() {
    SceneManager.LoadScene("Login");
    yield return 0;
  }
}
