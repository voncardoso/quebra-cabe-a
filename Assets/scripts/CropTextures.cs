using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CropTextures : MonoBehaviour
{
  //  public enum Options {
    //    Grid2X2 = 2,
	//	Grid3X3 = 3,
	//	Grid4X4 = 4,
	//	Grid5X5 = 5,
	//	Grid6X6 = 6,
	//	Grid7X7 = 7,
	//	Grid8X8 = 8,
	//	Grid9X9 = 9
   // };

   // public Options GridType;
    private int  GridType;
    public Texture2D sourceTexture; 
    public GameObject piecePrefab, gridPrefab;
	public UnityEngine.UI.Image img;

    private int amountPieces;
    private List<Vector2> positions = new List<Vector2>();
	private List<Vector2> sortedPositions = new List<Vector2>();
    private Vector2 position, distancePieces,resolutionPieces;


    // Start is called before the first frame update
    void Start()
    {
        StartComponents ();
		CreatePositions ();
		CreatePiece ();
    }

	public void voltarLogin(){
		StartCoroutine(ButtonVoltar());
	}

    void StartComponents(){
		GameManager.currentScore = 0;
        img.sprite = Sprite.Create (sourceTexture, new Rect (0, 0, sourceTexture.width, sourceTexture.height), new Vector2 (0.5f, 0.5f));
	  	GridType = Menu1.numeroPecas;
	   	amountPieces = GridType;
		resolutionPieces = new Vector2 (sourceTexture.width / amountPieces, sourceTexture.height / amountPieces);
    	GameManager.scoreTotal = amountPieces * amountPieces;
		
		
    }
	 // mantem od grids juntos
    void CreatePositions(){
		distancePieces = new Vector2 (resolutionPieces.x / 100.5f, resolutionPieces.y / 100.5f);
		for (int x = 0; x < amountPieces; x++) {
			for (int y = 0; y < amountPieces; y++){
				positions.Add(new Vector2(x*distancePieces.x, y*distancePieces.y));
			}
		}
	}

    	Vector2 RandomPosition(){
		var sorted = false;
		var pos = Vector2.zero;
		while (!sorted) {
			pos = positions[Random.Range(0, positions.Count)];
			sorted = !sortedPositions.Contains(pos);
			if (sorted)
				sortedPositions.Add(pos);
		}
		return pos;
	}

    	void CreatePiece(){	
		var start = amountPieces - 1;
		for (int i = start; i >= 0; i--) {
			for (int j = 0; j < amountPieces; j++){
				var texture = CropTexture(j, i);
				position = RandomPosition();
				var quad = Instantiate(piecePrefab, position, Quaternion.identity) as GameObject;
				quad.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
				quad.GetComponent<PieceScript>().startPosition = position;
				quad.GetComponent<BoxCollider2D>().size = new Vector2(distancePieces.x, distancePieces.y);		
                CreateGrid(j, i, quad);
            }
		}
	}

        Texture2D CropTexture(int j, int i){
        var resolutionX = Mathf.RoundToInt (resolutionPieces.x);
		var resolutionY = Mathf.RoundToInt (resolutionPieces.y);
        Color[] pixels = sourceTexture.GetPixels(j*resolutionX, i*resolutionY, resolutionX, resolutionY);

        Texture2D tex = new Texture2D(resolutionX, resolutionY);
		tex.SetPixels(pixels);
		tex.Apply();
		return tex;
    }
     void CreateGrid(int j, int i, GameObject quad){
         var grid = Instantiate (gridPrefab, new Vector2((j*distancePieces.x) - 10, i*distancePieces.y), Quaternion.identity) as GameObject;
         var newScale = new Vector2(resolutionPieces.x/150f, resolutionPieces.y/150f);
         grid.transform.localScale = new Vector3(newScale.x, newScale.y, 0);
		 quad.GetComponent<PieceScript> ().endPosition = grid.transform.position;
     }

	 IEnumerator ButtonVoltar(){
		SceneManager.LoadScene("Login");
    	yield return 0;
	 }
}
