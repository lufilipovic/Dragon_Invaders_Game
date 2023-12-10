using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{

    public TMP_Text enemyLeftText;
    public TMP_Text enemyKilledText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyLeftText.text = "Enemies Left: " + EnemyBehaviour.enemiesLeft.ToString();
        enemyKilledText.text = "Enemies Killed: " + EnemyBehaviour.enemiesKilled.ToString();
    }
}
