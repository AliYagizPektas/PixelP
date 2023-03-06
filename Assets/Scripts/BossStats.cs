using UnityEngine.UI;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    //UI
    [SerializeField]
    internal Image[] hearts;

    //Stats
    [SerializeField]
    internal static int health = 3;
    private int maxHealth = 3;

    public void Damage(int amount)
    {
        hearts[health - 1].enabled = false;
        health -= amount;

    }
    public void Regen(int amount)
    {
        health += amount;

        for (int i = 0; i < health; i++)
        {
            hearts[i].enabled = true;
        }

    }
    private void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }

}
