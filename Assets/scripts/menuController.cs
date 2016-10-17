using UnityEngine;
using System.Collections;
using SocketIO;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {
    public SocketIOComponent socketIO;
	public InputField connectionCodeField;
	public GameObject myCanvas;//this is my canvas 
	public GameObject mainmenu;
	public GameObject loadscreen;
    public GameObject mainGame;
    public GameObject hackathonCube;
    public Text errText;
    public Text WaitScreen;
    public Text endText;

    bool sent=false;
	// Use this for initialization
	void Start () {
        //disables all the menu items we don't want 
        hackathonCube.SetActive(false);
        loadscreen.SetActive(false);
        mainGame.SetActive(false);
        errText.gameObject.SetActive(false);
        WaitScreen.gameObject.SetActive(false);
        endText.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	public void appStart()
	{
        //listens for two messages, a success means you have a connection, a fail means you have to keep trying
        socketIO.On("ConnectionSuccess", waitState);
        socketIO.On("ConnectionFail", failCallback);
        socketIO.On("StartSafeGame", startSafe);
        socketIO.On("SafeVictory", victoryState);
        socketIO.On("StartTiltGame", startTilt);
        socketIO.On("TiltGameVictory", waitState);
        socketIO.On("StartCannonGame", startCannon);
        socketIO.On("CannonGameWin", waitState);
        mainmenu.SetActive(false);
		loadscreen.SetActive(true);


    }
    ///* ------------------------------------------
    //THIS IS WHERE THE NEW SCENES ARE LOADED
    
    // -------------------------------------------*/
    public void startTilt(SocketIOEvent e)
    {
        mainGame.SetActive(false);
        WaitScreen.gameObject.SetActive(false);
        SceneManager.LoadScene("gyroMaze", LoadSceneMode.Additive);
    }
    public void startSafe(SocketIOEvent e)
    {
        mainGame.SetActive(false);
        WaitScreen.gameObject.SetActive(false);

        SceneManager.LoadScene("listenGame", LoadSceneMode.Additive);
    }
    public void startCannon(SocketIOEvent e)
    {
        mainGame.SetActive(false);
        WaitScreen.gameObject.SetActive(false);
        SceneManager.LoadScene("cannonGame", LoadSceneMode.Additive);
    }
    public void waitForEvent()
    {
        print("callback2");
        print("this is here");
        mainmenu.SetActive(false);
        loadscreen.SetActive(false);
        mainGame.SetActive(true);
        WaitScreen.gameObject.SetActive(true);
        
    }
    public void victoryState(SocketIOEvent e)
    {
        mainGame.SetActive(false);
        hackathonCube.SetActive(true);
        endText.gameObject.SetActive(true);
    }
    public void buttonclick()
	{
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["code"] =connectionCodeField.text;
        socketIO.Emit("NewMobileConnection", new JSONObject(data));
        appStart(); 

	}
    void waitState(SocketIOEvent e) {

        waitForEvent();

    }
    
    void failCallback(SocketIOEvent e)
    {
        Debug.Log(e.data);
        loadscreen.SetActive(false);
        mainmenu.SetActive(true);
        errText.gameObject.SetActive(true);
    }
    public SocketIOComponent getSocket()
    {
        return socketIO;
    }
}
