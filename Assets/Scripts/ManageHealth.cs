using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManageHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public GameObject playerController;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI healthText;

    void Start()
    {
        player.health = player.startHealth;
        gameOverText.enabled = false;
        healthText.text = string.Format("Health remaining: {0}", player.health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void subtractHealth(int damageTaken = 1)
    {
        player.health -= damageTaken;
        Debug.Log(string.Format("Health remaining: {0}", player.health));
        healthText.text = string.Format("Health remaining: {0}", player.health);
        checkGameOver();
    }

    public void checkGameOver()
    {
        if (player.health <= 0)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        Debug.Log("YOU LOSE, GO SNEEZE YOU WEAKLING");
        gameOverText.enabled = true;
    }

    public void restartGame() //move to a system manager script instead
    {
        player.health = player.startHealth;
    }
}
