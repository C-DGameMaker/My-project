using TMPro;
using UnityEngine;

public class TurnBasedCombat : MonoBehaviour
{
    [SerializeField] int playerCurrentHealth;
    [SerializeField] int playerMaxHealth;

    [SerializeField] int enemyCurrentHealth;
    [SerializeField] int enemyMaxHealth;

    [SerializeField] TextMeshProUGUI playerHealthString;
    [SerializeField] TextMeshProUGUI enemyHealthString;

    [SerializeField] GameObject player;
    [SerializeField] Transform playerStartLocation;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform enemyStartLocation;

    [SerializeField] int playerAttack;
    [SerializeField] int enemyAttack;

    private bool isPlayerTurn;

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        enemyCurrentHealth = enemyMaxHealth;

        playerStartLocation = player.transform;
        enemyStartLocation = enemy.transform;

        HealthTextUpdate();

        isPlayerTurn = true;
    }

    private void HealthTextUpdate()
    {
        playerHealthString.text = playerCurrentHealth.ToString() + " / " + playerMaxHealth.ToString();
        enemyHealthString.text = enemyCurrentHealth.ToString() + " / " + enemyMaxHealth.ToString();
    }

    private void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;
    }
}
