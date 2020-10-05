using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Menu1 : MonoBehaviour
{
         enum Options {
        Grid2X2 ,
		Grid3X3 ,
		Grid4X4 ,
		Grid5X5 ,
		Grid6X6 ,
		Grid7X7 ,
		Grid8X8 ,
		Grid9X9 
    };
    
    public Dropdown dropdown;
    public Text selectedName;



    void Start()
    {
        ListdropDown();
    }
 
    
    void ListdropDown()
    {
        string[] enumNames = Enum.GetNames(typeof(Options));
        List<string> names = new List<string>(enumNames);

        this.dropdown.AddOptions(names);
    }

    public void Dropdown_List(){
       
       this.selectedName.text = $"value: {this.dropdown.value} {this.dropdown.captionText.text}";
       if(this.dropdown.value == 0){
           print(2);
       }

    }
}   

