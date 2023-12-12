using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public GameObject projectilePrefab;

    public float projectileSpeed = 5f;
    public float shootCooldown = 2f;

    private float lastShootTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastShootTime > shootCooldown)
        {
            Shoot();

            lastShootTime = Time.time;
        }
    }

    public void Shoot()
    {
        //Calculate the fire point position
        Vector3 firepointPosition = transform.position;

        //Instantiate new projectile with position and rotation
        GameObject projectile = Instantiate(projectilePrefab, firepointPosition, Quaternion.identity);

        //Rigidbody2D compoment that uses physics from Unity, to be affected by gravity, and setting its velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();


        if(rb != null)
        {
            //Shoot towards the player
            Vector2 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - firepointPosition).normalized;
            rb.velocity = direction * projectileSpeed;
        }
    }
}
