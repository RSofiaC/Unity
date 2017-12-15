//Serial Communication for two arduino buttons that move the gameobject on  axis
//Regina Cantu from https://www.youtube.com/watch?v=of_oLAvWfSI
//Winter 2017 - ITP
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Need this line to initialize ports
using System.IO.Ports;

public class serialMove : MonoBehaviour {

	public float speed; //Speed allows to control the behaviour in the interface
	private float amountToMove; //The variable needed to apply the speed float
	SerialPort sp = new SerialPort("/dev/cu.usbmodem1421",9600); //Give the name of the port and the baudrate that was printed in Arduino

	// Use this for initialization
	void Start () {
		sp.Open ();
		sp.ReadTimeout = 1;
	}

	// Update is called once per frame
	void Update () {

		amountToMove = speed * Time.deltaTime; //This updates the object to the time (move object Xm per second)
		//Try catch implemented to get the serial port
		if (sp.IsOpen) {
			try
			{
				MoveObject(sp.ReadByte());
				print(sp.ReadByte());
			}
			catch (System.Exception){
			}
		}

	}
		void MoveObject(int Direction){
			//This is the instruction for button 1 (pin 6)
			if (Direction == 1) {
				transform.Translate (Vector3.left * amountToMove, Space.World);
			}
			//This is the instruction for button 1 (pin 7)
			if (Direction == 2) {
				transform.Translate (Vector3.right * amountToMove, Space.World);
			}
		}

}