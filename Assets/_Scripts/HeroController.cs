/*
Source File Name = Hero Controller
Author's Name = Shivam Patel
Last Modified By = Shivam Patel
Date Last Modified = March 01,2016
Revision History = Revised on March 01
Program Description = This program is controller of the main hero. 
*/






using UnityEngine;
using System.Collections;

//VELOCITY RANGE UTILITY CLASS
[System.Serializable]
public class VelocityRange
{
    //public instance variables
    public float minimum;
    public float maximum;

    //constructor
    public VelocityRange(float minimum, float maximum)
    {
        this.minimum = minimum;
        this.maximum = maximum;
    }
}


public class HeroController : MonoBehaviour
{
    //PRIVATE INSTANCE VARIABLES

    private Animator _animator;
    private float _move;
    private float _jump;
    private bool _facingRight = true;
    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    // private bool _isGrounded = true; 
    public GameController gameController;
    private int position; // it describes what position the player should start with


    //public instance variables
    public VelocityRange velocityRange;
    public float moveForce;
    public float jumpForce;
    // public Transform groundCheck;
    public Transform camera;
    //public GameController gameController;


    // Use this for initialization
    void Start()
    {
        this.velocityRange = new VelocityRange(300f, 30000f);
        this._animator = gameObject.GetComponent<Animator>();
        this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        this._move = 50f;
        this._jump = 50f;
        this._facingRight = true;
        position = 0; // the position from where the hero will start the game


        this._jump = 0f;
        //setting the hero animator state to idle
        this._animator.SetInteger("anim_state", 0);
        this._transform = gameObject.GetComponent<Transform>();
        this._spawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentPosition = new Vector3(this._transform.position.x + 80, this._transform.position.y + 80, -10f);
        this.camera.position = currentPosition;
        float forceX = 0f;
        float forceY = 0f;

        //creating absolute value of velocity
        float absVelX = Mathf.Abs(this._rigidbody2D.velocity.x);
        float absVelY = Mathf.Abs(this._rigidbody2D.velocity.y);

        this._move = Input.GetAxis("Horizontal");
        this._jump = Input.GetAxis("Vertical");
        if (this._move != 0)
        {
            if (this._move > 0)
            {
                this._transform.position += new Vector3(2f, 3f, 0);
                this._facingRight = true;
                this._flip();
            }
            else
            {
                this._transform.position -= new Vector3(2f, -3f, 0);
                this._facingRight = false;
                this._flip();
            }
        }
        if (this._jump > 0)
        {

            if (absVelY < this.velocityRange.maximum)
            {
                this._transform.position += new Vector3(0, 10f, 0);
                forceY = this.jumpForce;
            }
            // this._isGrounded = false;
            //call the jump
            this._animator.SetInteger("anim_state", 1);

        }
        else
        {
            this._animator.SetInteger("anim_state", 0);
        }

        this._rigidbody2D.AddForce(new Vector2(forceX, forceY + 10));
    }

    //private methods
    private void _flip()
    {
        if (this._facingRight)
        {
            this._transform.localScale = new Vector2(40, 40);
        }
        else
        {
            this._transform.localScale = new Vector2(-40, 40);
        }
    }
    private void _spawn()
    {
        this._transform.position = new Vector3(-237f, 210f, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        string str = other.gameObject.name;
        if (str == "BG_Blue 1")
        {
            this._animator.SetInteger("anim_state", 0);
            this.gameController.LivesValue--;
            if (this.gameController.LivesValue != 0)
            {
                this._animator.SetInteger("anim_state", 1);
                if (position == 1)
                    this._transform.position = new Vector3(608f, -22f, 0);   //key position one
                if (position == 2)
                    this._transform.position = new Vector3(2640f, -200f, 0);    //key position two
                if (position == 0)
                    this._transform.position = new Vector3(-237f, 210f, 0);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (str == "key1" || str == "key2")
        {
            if(str == "key1")
            {
                this.position = 1;
            }
            else
            {
                this.position = 2;
            }
            this.gameController.keyValue--;
            Destroy(other.gameObject);
        }

        if (str == "Winner")
        {
            if (this.gameController.keyValue == 0)
            {
                this.gameController.levelValue++;
                this.position = 3;
                this._transform.position = new Vector3(-100f, -1700f);
            }
            else
            {
                this.gameController.HighScoreLabel.text = "First collect all the keys. Keys Left:" + this.gameController.keyValue;
            }
        }

        

        if(str.Substring(0,3) == "see")
        {
            Destroy(other.gameObject);
            this.gameController.ScoreValue += 5;
        }

        if(str == "BG_06")
        {
            this._transform.position = new Vector3(-100f, -1700f);
            this.gameController.LivesValue--;
        }

        if(str.Substring(0,4) == "fire")
        {
            this._transform.position = new Vector3(-100f, -1700f);
            this.gameController.LivesValue--;
        }

        if(str.Substring(0,4) == "drag")
        {
            this.gameController.LivesValue--;
            if (this.gameController.LivesValue != 0 && this.gameController.levelValue == 1)
            {
                this._animator.SetInteger("anim_state", 1);
                if (position == 1)
                    this._transform.position = new Vector3(608f, -22f, 0);   //key position one
                if (position == 2)
                    this._transform.position = new Vector3(2640f, -200f, 0);    //key position two
                if (position == 0)
                    this._transform.position = new Vector3(-237f, 210f, 0);
            }
            else if (this.gameController.LivesValue != 0 && this.gameController.levelValue == 2)
            {
                this._transform.position = new Vector3(-100f, -1700f);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

}
