/*
Source File Name = GameController
Author's Name = Shivam Patel
Last Modified By = Shivam Patel
Date Last Modified = March 01,2016
Revision History = Revised on March 01
Program Description = This program is controller of the game. It is mostly used to modify the textual content that would
            be visible on the screen. 
*/


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;
    private int _levelValue;
    private int _keyValue;

    public bool winner;
    // PUBLIC ACCESS METHODS
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }

    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            else {
                this.LivesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }

    public int levelValue
    {
        get
        {
            return this._levelValue;
        }

        set
        {
            this._levelValue = value;
            this.LevelLabel.text = "Level: " + this._levelValue;
        }
    }


    public int keyValue
    {
        get
        {
            return this._keyValue;
        }

        set
        {
            this._keyValue = value;
            this.KeyLabel.text = "Keys Left: " + this._keyValue;
        }
    }




    // PUBLIC INSTANCE VARIABLES
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text LevelLabel;
    public Text GameOverLabel;
    public Text HighScoreLabel;
    public Button RestartButton;
    public Text KeyLabel;
    // Use this for initialization
    void Start()
    {
        this._initialize();
    }

    // Update is called once per frame
    void Update()
    {
        RestartButton.onClick.AddListener(RestartButtonClick);
    }

    //PRIVATE METHODS ++++++++++++++++++

    //Initial Method
    private void _initialize()
    {
        this.ScoreValue = 0;
        this.LivesValue = 5;
        this.levelValue = 1;
        this.keyValue = 2;
        this.winner = false;
        this.GameOverLabel.gameObject.SetActive (false);
        this.HighScoreLabel.gameObject.SetActive (false);
        this.RestartButton.gameObject.SetActive(false);
        this.LivesLabel.gameObject.SetActive(true);
        this.ScoreLabel.gameObject.SetActive(true);
        this.LevelLabel.gameObject.SetActive(true);
        this.KeyLabel.gameObject.SetActive(true);
    }

    private void _endGame()
    {
        if(winner == false)
        { 
        this.HighScoreLabel.text = "High Score: " + this._scoreValue;
        this.GameOverLabel.gameObject.SetActive (true);
        this.HighScoreLabel.gameObject.SetActive (true);
        this.LivesLabel.gameObject.SetActive(false);
        this.ScoreLabel.gameObject.SetActive(false);
        this.LevelLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive (true);
        this.KeyLabel.gameObject.SetActive(false);
        }
        else
        {
            this.HighScoreLabel.text = "High Score: " + this._scoreValue;
            this.GameOverLabel.text = "YOU WON";
            this.GameOverLabel.gameObject.SetActive(true);
            this.HighScoreLabel.gameObject.SetActive(true);
            this.LivesLabel.gameObject.SetActive(false);
            this.ScoreLabel.gameObject.SetActive(false);
            this.LevelLabel.gameObject.SetActive(false);
            this.RestartButton.gameObject.SetActive(true);
            this.KeyLabel.gameObject.SetActive(false);
        }
    }

    // PUBLIC METHODS

    public void RestartButtonClick()
    {
        this._initialize();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}