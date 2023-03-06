using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //UI

    public Image[] hearts;

    //Stats
    public int health = 3;
    private int maxHealth = 3;

    public void Damage(int amount)
    {
        hearts[health - 1].enabled = false;
        health -= amount;

    }
    public void Regen(int amount)
    {
        health += amount;

        for(int i = 0; i < health; i++)
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
        // Admin Health Test
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (health < maxHealth)
            {
                Regen(1);
            }

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (health > 0)
            {
                Damage(1);
            }
        }
        // Admin Health Test
    }

}
