using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {set; get;}
    public GameObject mainMenu;
    public GameObject serverMenu;
    public GameObject connectMenu;
    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        serverMenu.SetActive(false);
        connectMenu.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ConnectButton(){
        Debug.Log("Connect btn clicked");
        mainMenu.SetActive(false);
        connectMenu.SetActive(true);
    }
    public void HostButton(){
        Debug.Log("Host btn clicked");
        mainMenu.SetActive(false);
        serverMenu.SetActive(true);
    }
    public void ConnectToServerBtn(){

    }
    public void BackButton(){
        mainMenu.SetActive(true);
        serverMenu.SetActive(false);
        connectMenu.SetActive(false);
    }
}
