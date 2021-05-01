using UnityEngine;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;
using UnityEngine.UI;

public class TemperatureSensor : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string lightsTopic = "home/lights";
    public float reportRate = 20f;
    public float temperatureValue = 20.3f;

    private MqttClient client;
    private float reportTimer;

    public Text text;
    public Text tempText;

    void Start ()
    {
		// create client instance 
		//client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null);
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId);

        string time = System.DateTime.UtcNow.ToLocalTime().ToString("M/d/yy  hh:mm tt");

        text.text = time;
	}

    void Update()
    {
        if ((reportTimer += Time.deltaTime) >= reportRate)
        {
                
            Debug.Log($"sending to topic {lightsTopic}, value: {temperatureValue}");
            string message = temperatureValue.ToString();
			client.Publish(lightsTopic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
            reportTimer = 0f;

            tempText.text = "Temp: " + message + "°C";
        }
    }
}
