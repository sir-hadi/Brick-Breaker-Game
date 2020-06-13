using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ini aslinya gak ada
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public Text highScoreText;
    public InputField highScoreInput;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject loadLevelPanel;
    public int numberOfBricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives : " + lives;
        scoreText.text = "Score : " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        Debug.Log("Number of Bricks  : " + numberOfBricks);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadLevel() {
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        gameOver = false;
        loadLevelPanel.SetActive(false);
    }

    void GameOver() {
        gameOver = true;
        gameOverPanel.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if(score > highScore) {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            highScoreText.text = "New High Score : " + score;
            highScoreInput.gameObject.SetActive(true);
        } else {
            highScoreText.text = PlayerPrefs.GetString("HIGHSCORENAME") + "'s" + " High Score : " + highScore + "\n" + "Can you beat it? :v";
        }
    }

    public void NewHighScore() {
        string highScoreName = highScoreInput.text;
        PlayerPrefs.SetString("HIGHSCORENAME", highScoreName);
        highScoreInput.gameObject.SetActive(false);
        highScoreText.text = "Congrast " + highScoreName + "\nWith a High Score Of " + score;
    }

    //dibikin gini soalnya bisa aja nanti ada fitur nambahin nyawa, jadi enak dia flexsible, bisa nambah, bisa kurang
    public void updateLives(int liveChanges) {
        lives += liveChanges;
        if(lives <= 0) {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives : " + lives;
    }

    //sama kek updateLives cuma ini score, bisa aja ada brick yang ngurangin poin kalo kena, jadi flexsible juga, bisa nambah, bisa kurang
    public void updateScore(int scoreChanges) {
        score += scoreChanges;
        scoreText.text = "Score : " + score;
        
    }

    public void reduceNumberOfBricks() {
        numberOfBricks--;
        if(numberOfBricks <= 0) {
            if (currentLevelIndex >= levels.Length -1) {
                GameOver();
            } else {
                loadLevelPanel.SetActive(true);
                loadLevelPanel.GetComponentInChildren<Text>().text = "Level " + (currentLevelIndex + 2);
                gameOver = true;
                Invoke("LoadLevel", 3f);
            }
        }
    }


    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit() {
        SceneManager.LoadScene("StartMenu");
        Debug.Log("Game is Quited to Start Menu");
    }
}
