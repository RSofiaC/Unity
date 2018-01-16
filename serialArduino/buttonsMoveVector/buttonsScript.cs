//Serial Communication for two arduino buttons
//Regina Cantu from https://www.youtube.com/watch?v=of_oLAvWfSI
//Winter 2017 - ITP
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class buttonScript : MonoBehaviour {

	public float speed;//you can default the speed here if you don´t need to be 
                       //changing it otherwise default to 0 so you can modify in the editor
    private float amountToMove;//specific to the object it is attached to
    SerialPort sp = new SerialPort("/dev/cu.usbmodem1421",9600);

	// Use this for initialization
	void Start () {
		sp.Open ();
		sp.ReadTimeout = 1; //Give Unity 1 milisecond to read the operation before sending a TimeOut
    }
	
	// Update is called once per frame
	void Update () {

		amountToMove = speed * Time.deltaTime;//This makes it framerate independent
                                              //i.e. move per second not per frame
        if (sp.IsOpen)
            if (sp.IsOpen) {
			try
			{
				MoveObject(sp.ReadByte());
				print(sp.ReadByte());
			}
			catch (System.Exception) //catch the exception in case serial is not communicating so Unity wont freeze
                {

            }
		}

    }

    //This is a special function for this script the argument is what we get from Arduino
    void MoveObject(int Direction){
		if (Direction == 1) {
			transform.Translate (Vector3.left * amountToMove, Space.World);
		}
		if (Direction == 2) {
			transform.Translate (Vector3.right * amountToMove, Space.World);
		}
	}
}
