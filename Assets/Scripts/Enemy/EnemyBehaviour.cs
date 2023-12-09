using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip destructionSFX;

    //Variable to keep track of the total number of aliens
    public static int enemiesLeft = 0;

    public void Start()
    {
        // Increment the alien count when an alien is created
        enemiesLeft++;
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
			// Play an audio clip in the scene and not attached to the alien
			// so the sound keeps playing even after it's destroyed
            AudioSource.PlayClipAtPoint(destructionSFX, Vector3.zero);

            // Destroy the alien game object
            Destroy(gameObject);

            // Destroy the projectile game object
            Destroy(collision.gameObject);


        }

        // Decrement the alien count when an alien is destroyed
        enemiesLeft--;
        print(enemiesLeft);

        // Check if there are no aliens left
        if (enemiesLeft == 0)
        {
            // All aliens are destroyed
            print("All aliens destroyed!");

        }

    }

}
