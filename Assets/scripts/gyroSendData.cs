using UnityEngine;
using System.Collections;
using SocketIO;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gyroSendData : MonoBehaviour {

    public SocketIOComponent socketIO;
    public Vector3 currentPos;
    Dictionary<string, string> data = new Dictionary<string, string>();

    // Use this for initialization
    void Start()
    {
        // Activate the gyroscope
        Input.gyro.enabled = true;

        Screen.sleepTimeout = 0;
        socketIO = ((GameObject.FindGameObjectWithTag("socket")).GetComponent<menuController>()).getSocket();
        socketIO.On("TiltGameVictory", victory);
    }

    // Update is called once per frame
    void Update()
    {
       //send gyroscope data to the server 
        data["x"] = Input.gyro.attitude.x.ToString();
        data["y"] = Input.gyro.attitude.y.ToString();
        data["z"] = Input.gyro.attitude.z.ToString();
       
        socketIO.Emit("TiltData", new JSONObject(data));
    }
    void victory(SocketIOEvent e)
    {
        SceneManager.UnloadScene("gyroMaze");
    }
}
