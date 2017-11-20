using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour {

    bool beatHighScore;
    //UI elements referenced into the Editor
    public Text ScoreText;
    public Text FinalText;
    public Text FinalScoreText;
    public Text HighScoreText;

    public Image JumpButton;
    public Image MainMenuScreen;
    public Image FirstTapScreen;
    public Image GameOverScreen;

	// Use this for initialization
	void Start () { //Initializing of data in the GameData class
        GameData.gameScore = 0;
        GameData.gameBegins = false;
        GameData.gameOver = false;
        GameData.gameHighScore = PlayerPrefs.GetInt("high_score", 0);
        HighScoreText.text = GameData.gameHighScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "" + GameData.gameScore;
        ShowGameOverScreen();
	}

    void ShowGameOverScreen() // Tells the game when to show the game over screen
    {
        if (GameData.gameOver)
        {
            GameOverScreen.gameObject.SetActive(true);
            FinalScoreText.text = GameData.gameScore.ToString();
            beatHighScore = CheckHighScore();
            if (beatHighScore)
            {
                FinalText.text = "NEW";
                FinalText.color = Color.green;
            }
            else if (!beatHighScore)
            {
                FinalText.text = "FINAL";
                FinalText.color = Color.white;
            }
            ScoreText.gameObject.SetActive(false);  // Hides the score text
        }
        else if (!GameData.gameOver)
        {
            GameOverScreen.gameObject.SetActive(false);
        }
    }

    public void StartGame() //Call this method to begin game
    {
        MainMenuScreen.gameObject.SetActive(false); //Hides the main menu screen
        FirstTapScreen.gameObject.SetActive(true); //Shows the first tap screen
    }

    public void HideFirstTapScreen()  //Hides the first tap screen
    {
        FirstTapScreen.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true); // Shows the score text
        GameData.gameBegins = true; // Game now begun
        JumpButton.gameObject.SetActive(true); // Jump button is now active
    }

    bool CheckHighScore()
    {
        if(GameData.gameScore > GameData.gameHighScore)
        {
            GameData.gameHighScore = GameData.gameScore;
            PlayerPrefs.SetInt("high_score", GameData.gameHighScore);
            return true;
        }
        else if (GameData.gameScore <= GameData.gameHighScore)
        {
            return false;
        }
        else
        {
            return false;
        }
    }

    public void GoToMainMenu() // Restarts the scene
    {
        SceneManager.LoadScene("game");
    }
}
