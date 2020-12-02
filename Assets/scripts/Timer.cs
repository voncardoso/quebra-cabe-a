using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //variavel irá receber o nome da cena
    private string nomeCena;
    // recebe o tempo no formato de texto
    private Text timeLevel_txt;
    // conta o tempo
    private float timeLevel;
    // vai manda o tempo para banco
    private static string timeLevel_banco;

    public static bool estopTime;
    
    void Start()
    {
        estopTime = false;

        nomeCena = SceneManager.GetActiveScene().name;
        print(nomeCena);
        Update();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estopTime == false){
            timeLevel = timeLevel + Time.deltaTime;
            timeLevel_txt.text = timeLevel.ToString("F0");    
            timeLevel_banco = timeLevel_txt.text;
            print("timer banco " + timeLevel_banco);
        }
        TimerLevelCena (timeLevel_banco);
        
    }

    void TimerLevelCena (string X){
        print("aqui");
            if(nomeCena == "Jogar"){
                print("timer banco final" + timeLevel_banco);
            }
            if(nomeCena == "Jogar-2"){
                timeLevel_banco = timeLevel_txt.text;
                print("timer banco" + timeLevel_banco);
            }      
    }

}
