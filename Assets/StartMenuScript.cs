using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour {

    public Text highScoreText;
    private void Start() {
        if (PlayerPrefs.GetString("HIGHSCORENAME") != "") {
            highScoreText.text = "Highscore is by " + PlayerPrefs.GetString("HIGHSCORENAME") + ", score is " + PlayerPrefs.GetInt("HIGHSCORE");
        }
    }
    public void QuitGame() {
        Application.Quit();
        Debug.Log("Game Is Quited");
    }

    public void StartGame() {
        SceneManager.LoadScene("SampleScene");
    }

}
