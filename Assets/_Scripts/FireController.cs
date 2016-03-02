/*
Source File Name = FireController
Author's Name = Shivam Patel
Last Modified By = Shivam Patel
Date Last Modified = March 01,2016
Revision History = Revised on March 01
Program Description = This is the controller for the fire of the monster dragon which the hero has to miss 10 
                times to win the game.
*/

using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{
    // PUBLIC INSTANCE VARIABLES
    public float speed = 5f;
    public GameController gameController;


    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    public Vector2 _currentPosition;
    private int _count;

    // Use this for initialization
    void Start()
    {
        // Make a reference with the Transform Component
        _count = 10;
        this._transform = gameObject.GetComponent<Transform>();
        this._transform.position = this._currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this._currentPosition = this._transform.position;
        this._currentPosition -= new Vector2(this.speed, 0);
        this._transform.position = this._currentPosition;

        if (this._transform.position.x <= -200f)
        {
            this._transform.position = new Vector2(427,-1973f);
            if(this.gameController.levelValue == 2)
            { 
            _count--;
            }
        }

        if(_count == 0)
        {
            this.gameController.winner = true;
        }

    }
}