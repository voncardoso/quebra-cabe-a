using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;



public class Menu : MonoBehaviour
{

    public enum Options {
        Grid2X2 = 2,
		Grid3X3 = 3,
		Grid4X4 = 4,
		Grid5X5 = 5,
		Grid6X6 = 6,
		Grid7X7 = 7,
		Grid8X8 = 8,
		Grid9X9 = 9
    };
    public Dropdown dropdown;
    
    void Start()
    {
        Dropdown_quantidadePeças(typeof(Options), dropdown);
        
    }

    // Update is called once per frame
     void Update()
    {
        
    }

    public void Dropdown_quantidadePeças(Type t, Dropdown add)
    {
        add.ClearOptions();

        for(int x = 0; x < Enum.GetNames(t).Length; x++)
        {
            var doptions = new Dropdown.OptionData();
            doptions.text = Enum.GetValues(t).GetValue(x).ToString();
            add.options.Add(doptions);
        }  
        Debug.Log(dropdown);
    }
}
