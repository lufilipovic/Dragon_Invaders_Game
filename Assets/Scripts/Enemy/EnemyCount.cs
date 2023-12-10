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
    public Button exitButton;

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
        winningText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemyLeftText.text = "Enemies Left: " + EnemyBehaviour.enemiesLeft.ToString();
        enemyKilledText.text = "Enemies Killed: " + EnemyBehaviour.enemiesKilled.ToString();
        if (EnemyBehaviour.enemiesKilled > 0 && EnemyBehaviour.enemiesLeft == 0)
        {
            winGame();
        }

    }

    public void winGame()
    {
        gameOverPanel.gameObject.SetActive(true);
        winningText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void startScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
