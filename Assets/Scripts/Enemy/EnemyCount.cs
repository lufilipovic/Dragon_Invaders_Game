using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{

    public TMP_Text enemyLeftText;
    public TMP_Text enemyKilledText;

    public TMP_Text winningText;

    public Button restartButton;
    public Button continueButton;
    public Button exitButton;

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        //remove objects at start
        gameOverPanel.gameObject.SetActive(false);
        winningText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //setting text to number of enemies
        enemyLeftText.text = "Enemies Left: " + EnemyBehaviour.enemiesLeft.ToString();
        enemyKilledText.text = "Enemies Killed: " + EnemyBehaviour.enemiesKilled.ToString();

        //check if the player killed all enemies
        if (EnemyBehaviour.enemiesKilled > 0 && EnemyBehaviour.enemiesLeft == 0)
        {
            winGame();
        }

    }

    //show objects on call of the method
    public void winGame()
    {
        gameOverPanel.gameObject.SetActive(true);
        winningText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

    }

    //reload the current scene
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //load the next scene from the build
    public void continueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //load first scene from the build
    public void startScreen()
    {
        SceneManager.LoadScene(0);
    }


    //load the previous scene from the build
    public void goBackScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
