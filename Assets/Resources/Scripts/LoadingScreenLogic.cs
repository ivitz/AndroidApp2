using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenLogic : MonoBehaviour {

    //public static string sceneName;
    public Slider slider;

    public Text loadingText;

    private AsyncOperation asyncLoad = null;

    private bool allowLoad;

    public void Load(string sceneName)
    {
        slider.gameObject.SetActive(true);
        StartCoroutine(LoadYourAsyncScene(sceneName));  
    }
	
    /// <summary>
    /// Loads your async scene. You need to pass here the name of your next scene.
    /// </summary>
    /// <param name="nameOfScene">Name of scene.</param>
    IEnumerator LoadYourAsyncScene(string nameOfScene)
    {  
        asyncLoad = SceneManager.LoadSceneAsync(nameOfScene);

        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {          
            loadingText.text = "Loading level: " + Mathf.Round (asyncLoad.progress * 100).ToString() + "%";
            slider.value = asyncLoad.progress;
            yield return null;
        }

        StartTheScene();

        while (!allowLoad)
        {           
            slider.value = 1;
            yield return null;
        }

        yield return new WaitForEndOfFrame();
        yield return null;

        asyncLoad.allowSceneActivation = true;
    }

    public void StartTheScene() 
    { 
        allowLoad = true;
    }


}
