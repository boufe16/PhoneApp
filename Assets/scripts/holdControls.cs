using UnityEngine;
using System.Collections;
using SocketIO;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class holdControls : MonoBehaviour
{
    public SocketIOComponent socketIO;
    public Vector3 currentPos;
    Dictionary<string, string> data = new Dictionary<string, string>();
    // Use this for initialization
    void Start()
    {

        socketIO = ((GameObject.FindGameObjectWithTag("socket")).GetComponent<menuController>()).getSocket();
        socketIO.On("CannonGameWin", victory);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            data["X"] = touch.position.x.ToString();
            data["Y"] = touch.position.y.ToString(); 
            
            socketIO.Emit("TouchXY", new JSONObject(data));
           
        }
    }
    void victory(SocketIOEvent e)
    {
        print("callbakc1");
        SceneManager.UnloadScene("cannonGame");
    }
}