using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{

    public TMP_Text enemyLeftText;

    public TMP_Text displayText;

    public GameObject gameOverPanel;

    public GameObject menuPanel;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //remove objects at start
        gameOverPanel.SetActive(false);
        displayText.gameObject.SetActive(false);
        menuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //setting text to number of enemies
        enemyLeftText.text = "Enemies Left: " + EnemyBehaviour.enemiesLeft.ToString();

        if (player == null)
        {
            displayText.text = "You lose!";
            WinGame();
        }
        //check if the player killed all enemies
        else if (EnemyBehaviour.enemiesKilled > 0 && EnemyBehaviour.enemiesLeft == 0)
        {
            displayText.text = "You win dragon slayer!";
            WinGame();
        }

        // Check if the Escape key is pressed
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            //toggle the menu panels active state 
            menuPanel.SetActive(!menuPanel.activeSelf);
        }

    }

    //show objects on call of the method
    public void WinGame()
    {
        gameOverPanel.SetActive(true);
        displayText.gameObject.SetActive(true);
        DestroyProjectiles();
    }

    //reload the current scene
    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        print(player);
    }

    //load the next scene from the build
    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //load first scene from the build
    public void StartScreen()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }


    //load the previous scene from the build
    public void GoBackScreen()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;

    }

    public void DestroyProjectiles()
    {
        // Find all active projectiles in the scene and destroy them
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");

        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }
    }

}
