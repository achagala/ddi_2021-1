using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;
using UnityEngine.UI;

public class TvController : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
    public string tvTopic = "home/tv";
    private MqttClient client;
    string lastMessage;
    public GameObject tv;
    public AudioClip sound;
    public float Volume;
    private AudioSource audio;
    volatile bool tvState = false;
    volatile bool lastState = false;

    public Text text;
    public Button button;
    public Color offColor;
    public Color onColor;

    //public GameObject objText;

    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
        client.Subscribe(new string[] { tvTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

        audio = GetComponent<AudioSource>();
        //button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tvState != tv.activeSelf)
        {  
            PlayTv();
        }
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);

        string command = lastMessage.ToLower();
        Debug.Log("Comando: " + command);

        if(command.Equals("tv on"))
        {
            lastState = tvState;
            tvState = true;
        }
        else if(command.Equals("tv off"))
            tvState = false;
	}

    private void PlayTv()
    {
        if(!lastState && tvState)
        {
            tv.SetActive(tvState);
            audio.PlayOneShot(sound, Volume);
            Debug.Log("Play TV");

            text.text = "TV: On";
            //button.GetComponent<Image>().color = onColor;
            //button.BackColor = Color.green;
            //ColorBlock cb = button.colors;
            //cb.normalColor = onColor;
            //button.colors = cb;
        }
        else
        {
            tv.SetActive(tvState);
            audio.Stop();
            Debug.Log("Stop Tv");

            text.text = "TV: Off";
            //button.GetComponent<Image>().color = offColor;
            //ColorBlock cb = button.colors;
            //cb.normalColor = offColor;
            //button.colors = cb;
        }         
    }
}

