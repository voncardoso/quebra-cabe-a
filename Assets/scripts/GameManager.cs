using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text;
    public static GameObject currentPiece;
    public static int currentScore, scoreTotal;

    void Update(){
        if (currentScore == scoreTotal){
         print(currentScore);
        print(scoreTotal);
            print("Parabens");
            text.text = "Parabens";
        }
    }
}
