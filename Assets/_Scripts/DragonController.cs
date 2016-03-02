/*
Source File Name = DragonController
Author's Name = Shivam Patel
Last Modified By = Shivam Patel
Date Last Modified = March 01,2016
Revision History = Revised on March 01
Program Description = This program is the controller for the dragon. It is for the automation of the dragon in the game.
*/

using UnityEngine;
using System.Collections;

public class DragonController : MonoBehaviour {
    //private instance variables
    private Transform _transform;
    private Rigidbody2D _rigid;
    private bool _facingRight = true;
    public float start;
    public float end;

    // Use this for initialization
    void Start () {
        this._transform = this.gameObject.GetComponent<Transform>();
        this._rigid = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(this._transform.position);
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(this._transform.position);
        if (this._transform.position.x > end)
        {
            this._transform.localScale = new Vector2(100, 100);
            _facingRight = true;
        }
        if(this._transform.position.x < start)
        {
            this._transform.localScale = new Vector2(-100, 100);
            _rigid.gravityScale = 100;
            _facingRight = false;
        }


        if(_facingRight)
        {
            Debug.Log("In true");
        this._transform.position -= new Vector3(10f, -10f, 0);
        }
        else
        {
            Debug.Log("In false");
            this._transform.position += new Vector3(10f,10f,0);
            Debug.Log(this._transform.position);
        }

    }
}
