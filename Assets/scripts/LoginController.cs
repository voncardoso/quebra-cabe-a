using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class Data
{
  public string type { get; set; }
  public string token { get; set; }
  public object refreshToken { get; set; }
}

[System.Serializable]
public class Response
{
  public Data data = new Data();
  public string message;
}

public class LoginController : MonoBehaviour
{
  [SerializeField]
  private InputField userFielde = null;

  [SerializeField]
  private InputField senhaFielde = null;

  [SerializeField]
  private Text feedBackmsg = null;



  public void FazerLogin()
  {
    StartCoroutine(EviarRequisicao());
  }

    public void jogoTeste()
  {
     StartCoroutine(CarregaJogo());
  }

  IEnumerator EviarRequisicao()
  {
    string endPoint = "localhost:3333/api/v1";
    string email = userFielde.text;
    string password = senhaFielde.text;

    WWWForm form = new WWWForm();
    form.AddField("email", email);
    form.AddField("password", password);

    UnityWebRequest w = UnityWebRequest.Post(endPoint + "/login", form);
    yield return w.SendWebRequest();

    if (w.isNetworkError || w.isHttpError)
    {
      feedBackmsg.text = "Email ou senha inválidos";
      userFielde.text = "";
      senhaFielde.text = "";
    }
    else
    {
      string json = w.downloadHandler.text;
      Response response = JsonConvert.DeserializeObject<Response>(json);

      string token = response.data.token;
      PlayerPrefs.SetString("token", token);

      StartCoroutine(CarregaScene());
    }
  }

  IEnumerator CarregaScene()
  {
    SceneManager.LoadScene("Inicial");
    yield return 0;
  }

  IEnumerator CarregaJogo()
  {
    SceneManager.LoadScene("Jogar");
    yield return 0;
  }

  

}
