using UnityEngine;
using System.Collections;
using SocketIO;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class listenGame : MonoBehaviour {
    public SocketIOComponent socketIO;
    public AudioSource src_small;
    public AudioSource src_large;

    // Use this for initialization
    void Start () {
        socketIO = ((GameObject.FindGameObjectWithTag("socket")).GetComponent<menuController>()).getSocket();

        Dictionary<string, string> data = new Dictionary<string, string>();
        data["code"] = "hello";
        socketIO.Emit("Success", new JSONObject(data));
        
        socketIO.On("SafeTick", tickSound);
        socketIO.On("SafeTock", tockSound);
        socketIO.On("SafeVictory", victory);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void tickSound(SocketIOEvent e)
    {
        src_small.Play();
        print("tick");
    }
    void tockSound(SocketIOEvent e)
    {
        src_large.Play();
        print("tock");
    }
    void victory(SocketIOEvent e)
    {
        print("callbakc1");
        SceneManager.UnloadScene("listenGame");
    }

}
