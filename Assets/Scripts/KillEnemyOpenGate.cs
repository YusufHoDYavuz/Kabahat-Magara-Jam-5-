using UnityEngine;
using TMPro;

public class KillEnemyOpenGate : MonoBehaviour
{
    public TextMeshProUGUI enemyValueTxt;
    public static int totalEnemyValue;
    public Collider wall;


    private void Start()
    {
        totalEnemyValue = 9;
        enemyValueTxt.text = totalEnemyValue.ToString();

        InvokeRepeating(nameof(PrintEnemyValue), 0, 1);      
    }

    void PrintEnemyValue()
    {
        enemyValueTxt.text = totalEnemyValue.ToString();
        if (totalEnemyValue <= 0) 
        {
            wall.isTrigger = true;
        }
    }
}
