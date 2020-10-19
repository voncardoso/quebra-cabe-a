using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtoScript : MonoBehaviour
{
    // Start is called before the first frame update
	public Image img;
	private bool isEnabled = false;
	
	public void ClickVewImage(){
		isEnabled = !isEnabled;
		if (isEnabled)
			img.gameObject.SetActive (true);
		else 
			img.gameObject.SetActive (false);
	}
	
	public void RestartLevel(){
		Application.LoadLevel (0);
	}
}
