using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KnightManager : MonoBehaviour
{
    private Knight player;
    private Knight enemy;

    public GameObject playerHealthTextObject;
    public GameObject playerPowerTextObject;
    public GameObject playerSpeedTextObject;

    public GameObject enemyHealthTextObject;
    public GameObject enemyPowerTextObject;
    public GameObject enemySpeedTextObject;

    public GameObject infoTextObject;
    public GameObject otherInfoTextObject;

    private TextMeshProUGUI playerHealthText { get; set; }
    private TextMeshProUGUI playerPowerText { get; set; }
    private TextMeshProUGUI playerSpeedText { get; set; }

    private TextMeshProUGUI enemyHealthText { get; set; }
    private TextMeshProUGUI enemyPowerText { get; set; }
    private TextMeshProUGUI enemySpeedText { get; set; }

    private TextMeshProUGUI infoText { get; set; }
    private TextMeshProUGUI otherInfoText { get; set; }

    public GameObject attackButton;
    public GameObject resetButton;

    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthText = playerHealthTextObject.GetComponent<TextMeshProUGUI>();
        playerPowerText = playerPowerTextObject.GetComponent<TextMeshProUGUI>();
        playerSpeedText = playerSpeedTextObject.GetComponent<TextMeshProUGUI>();

        enemyHealthText = enemyHealthTextObject.GetComponent<TextMeshProUGUI>();
        enemyPowerText = enemyPowerTextObject.GetComponent<TextMeshProUGUI>();
        enemySpeedText = enemySpeedTextObject.GetComponent<TextMeshProUGUI>();

        infoText = infoTextObject.GetComponent<TextMeshProUGUI>();
        otherInfoText = otherInfoTextObject.GetComponent<TextMeshProUGUI>();

        player = new Knight("You");
        enemy = new Knight("Enemy");

        infoText.text = "";
        otherInfoText.text = "";

        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the power and speed variables of both objects each frame to reflect the current value of the health variable
        player.UpdatePower();
        player.UpdateSpeed();

        enemy.UpdatePower();
        enemy.UpdateSpeed();

        playerHealthText.text = "Health: " + player.GetHealth().ToString();
        playerPowerText.text = "Power: " + player.GetPower().ToString();
        playerSpeedText.text = "Speed: " + player.GetSpeed().ToString();

        enemyHealthText.text = "Health: " + enemy.GetHealth().ToString();
        enemyPowerText.text = "Power: " + enemy.GetPower().ToString();
        enemySpeedText.text = "Speed: " + enemy.GetSpeed().ToString();

        CheckForDeath();
    }

    // Runs when the AttackButton object is clicked
    public void OnAttackButton()
    {
        if(gameOver == false)
        {
            Attack(player, enemy, infoText);
            Attack(enemy, player, otherInfoText);
        }
        
    }

    public void Attack(Knight attacker, Knight target, TextMeshProUGUI textBox)
    {
        // rolls number from 1-10
        int hitChance = Random.Range(1, 11);

        // if the number rolled by hitChance is less than the target's speed stat, they'll miss
        if(hitChance > target.GetSpeed())
        {
            int newHealth = target.GetHealth() - attacker.GetPower();
            
            target.SetHealth(newHealth);

            if(textBox == infoText)
            {
                textBox.text = attacker.GetName() + " swing at " + target.GetName() + " and deal " + attacker.GetPower().ToString() + " damage!";
            }
            else
            {
                textBox.text = attacker.GetName() + " swings at " + target.GetName() + " and deals " + attacker.GetPower().ToString() + " damage!";
            }
        }
        else
        {
            if(textBox == infoText)
            {
                textBox.text = attacker.GetName() + " swing at " + target.GetName() + " and miss!";
            }
            else
            {
                textBox.text = attacker.GetName() + " swings at " + target.GetName() + " and misses!";
            }
            
        }
    }

    public void OnResetButton()
    {
        player = new Knight("You");
        enemy = new Knight("Enemy");

        infoText.text = "";
        otherInfoText.text = "";

        gameOver = false;
    }

    public void CheckForDeath()
    {
        if(player.GetHealth() <= 0)
        {
            gameOver = true;
            infoText.text = "You died!";

            playerHealthText.text = "Health: -";
            playerPowerText.text = "Power: -";
            playerSpeedText.text = "Speed: -";

            otherInfoText.text = "";
        }

        if (enemy.GetHealth() <= 0)
        {
            gameOver = true;
            infoText.text = "Enemy has been defeated!";

            enemyHealthText.text = "Health: -";
            enemyPowerText.text = "Power: -";
            enemySpeedText.text = "Speed: -";

            otherInfoText.text = "";
        }
    }
}
