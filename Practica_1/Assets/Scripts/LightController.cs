using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
    public string lightsTopic = "home/lights";
    public float temperatureUpperThreshold = 30f;
    public float temperatureLowerThreshold = 20f;
    private MqttClient client;
    string lastMessage;
    public GameObject light;
    public Text text;

    volatile bool lightState = false;
    volatile bool lastLightState;

    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
        client.Subscribe(new string[] { lightsTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
    }

    // Update is called once per frame
    void Update()
    {
        if (lightState != light.activeSelf)
            Lights();
			
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		bool night;
        bool.TryParse(lastMessage, out night);

        if(lastMessage.Equals("light on"))
		{
			lightState = true;
		}
		else if(lastMessage.Equals("light off"))
		{
			lightState = false;
		}
	}

    private void Lights()
    {
        if(lightState)
        {
            light.SetActive(lightState);

            text.text = "Lights: On";
            
        }
        else
        {
            light.SetActive(lightState);

            text.text = "Lights: Off";
        }
            
    }
}
