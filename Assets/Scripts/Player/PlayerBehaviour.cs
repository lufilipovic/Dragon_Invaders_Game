using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour

{

    public AudioClip playerHitSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is an enemy projectile
        if (collision.tag == "EnemyProjectile")
        {
            // Play an audio clip for the player hit
            AudioSource.PlayClipAtPoint(playerHitSFX, transform.position);

            // Destroy the player and the enemy projectile
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // Pause the game
            Time.timeScale = 0f;

            // You may want to display a game over UI or handle other aspects of player death here
            print("Player Hit! Game Over!");
        }
    }
}
