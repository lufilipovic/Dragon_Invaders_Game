using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip destructionSFX;


    //Variable to keep track of the total number of enemies
    public static int enemiesLeft = 0;

    //Variable to keep track of enemies killed
    public static int enemiesKilled = 0;

    public void Start()
    {

    }

    // physical sim hits. For Unity to call this, at least one of the colliding objects
    // needs to have their RigidBody component set to "Dynamic" for Body Type
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // print("I'm hit collision!");
    }

    // This is called if the Collider on the game object has "Is Trigger" checked.
	// Then it doesn't physically react to hits but still detects them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("I'm hit!");

		// Check the other colliding object's tag to know if it's
		// indeed a player projectile
        if (collision.tag == "PlayerProjectile")
        {
			// Play an audio clip in the scene and not attached to the enemy
			// so the sound keeps playing even after it's destroyed
            AudioSource.PlayClipAtPoint(destructionSFX, Vector3.zero);

            // Destroy the enemy game object
            Destroy(gameObject);

            // Destroy the projectile game object
            Destroy(collision.gameObject);


        }

    }

    public void OnEnable()
    {
        // Increment the enemy count when an enemy is created
        enemiesLeft++;
    }

    public void OnDisable()
    {
        // Decrement the enemy count when an enemy is killed
        enemiesLeft--;

        // Increment the enemy count when an enemy is killed
        enemiesKilled++;

        if (enemiesLeft == 0)
        {
            // All enemies are destroyed
            Debug.Log("All enemies destroyed!");
        }
    }

}
