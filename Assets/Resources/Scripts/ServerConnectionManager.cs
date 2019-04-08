using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.IO;
using UnityEngine.UI;

public class ServerConnectionManager : MonoBehaviour {

    public Text serverResponseText;

    //will be displayed if the connection to server failed
    public GameObject playAnywayButton;

    public void Connect(string address)
    {
       StartCoroutine(GetResponse(address));
    }

    IEnumerator GetResponse (string address)
    {
        UnityWebRequest www = UnityWebRequest.Get(address);
        yield return www.Send();

        if (www.isError) 
        {
            playAnywayButton.SetActive(true);
            serverResponseText.text = "Server response: " +  www.error;
            Debug.Log("Server response: " + www.error);
        }
        else 
        {            
            Debug.Log("Server response: " + www.responseCode);
            serverResponseText.text = "Server response: " + www.responseCode;
            yield return new WaitForSeconds(1);
            GetComponent<LoadingScreenLogic>().Load("MainMenu");
        }
    }
}
