using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene : MonoBehaviour
{
   public void CambiarEscenaClick(string sceneName){
     StartCoroutine(retrasoEscena(sceneName));
  }

  public void SalirJuego(){
    Debug.Log("Saliendo del juego");
    Application.Quit();
  }

  IEnumerator retrasoEscena(string sceneName){
    yield return new WaitForSecondsRealtime(0.5f);
    SceneManager.LoadScene(sceneName);
  }

}
