using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Menu1 : MonoBehaviour
{
    enum Options {
        Grid2X2,
		Grid3X3,
		Grid4X4,
		Grid5X5,
		Grid6X6,
		Grid7X7,
		Grid8X8,
		Grid9X9,
    };
    
    public Dropdown dropdown;
    public static int numeroPecas;
    public Text selectedName;
     



    void Start()
    {
        ListdropDown();
    }
    
    public void Jogar(){
        StartCoroutine(ButtonJogar());
    }
 
    
    void ListdropDown()
    {
        string[] enumNames = Enum.GetNames(typeof(Options));
        List<string> names = new List<string>(enumNames);

        this.dropdown.AddOptions(names);
    }

    public void Dropdown_List(){
       
       this.selectedName.text = $"value: {this.dropdown.value} {this.dropdown.captionText.text}";
       if(this.dropdown.value == 1){
           numeroPecas = 2;
           print(numeroPecas);
       }
        
        if(this.dropdown.value == 2){
           numeroPecas = 3;
           print(numeroPecas);
       }
        
        if(this.dropdown.value == 3){
           numeroPecas = 4;
           print(numeroPecas);
       }

        if(this.dropdown.value == 4){
           numeroPecas = 5;
           print(numeroPecas);
       }
        if(this.dropdown.value == 5){
           numeroPecas = 6;
           print(numeroPecas);
       }

        if(this.dropdown.value == 6){
           numeroPecas = 7;
           print(numeroPecas);
       }

        if(this.dropdown.value == 7){
           numeroPecas = 8;
           print(numeroPecas);
       }
        if(this.dropdown.value == 8){
           numeroPecas = 9;
           print(numeroPecas);
       }

    }
    
    IEnumerator ButtonJogar(){
		SceneManager.LoadScene("Jogar");
    	yield return 0;
	 }
}   

