using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
   // private string nomeCena;
   // public Text bestTime;
    public Text timeLevel_txt;
    private float timeLevel;
    public static bool estopTime;
    // Start is called before the first frame update
    void Start()
    {
        estopTime = false;

        //nomeCena = SceneManager.GetActiveScene().jogar;
    }

    // Update is called once per frame
    void Update()
    {
        if (estopTime == false){
            timeLevel = timeLevel + Time.deltaTime;
            timeLevel_txt.text = timeLevel.ToString("F2");
        }
    }
}
