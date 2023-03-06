using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button seviye1_button, seviye2_button, seviye3_button, seviye4_button, seviye5_button, seviye6_button,
        seviye7_button, seviye8_button, seviye9_button, seviye10_button, seviye11_button, seviye12_button, seviye13_button,
        seviye14_button, seviye15_button;
    public static bool seviye1, seviye2, seviye3, seviye4, seviye5, seviye6, seviye7, seviye8,
        seviye9, seviye10, seviye11, seviye12, seviye13, seviye14, seviye15;
    private void Start()
    {
        seviye1 = true;
    }
    private void Update()
    {
        if (seviye2 == true)
        {
            seviye2_button.interactable = true;
        }
        if (seviye3 == true)
        {
            seviye3_button.interactable = true;
        }
        if (seviye4 == true)
        {
            seviye4_button.interactable = true;
        }
        if (seviye5 == true)
        {
            seviye5_button.interactable = true;
        }
        if (seviye6 == true)
        {
            seviye6_button.interactable = true;
        }
        if (seviye7 == true)
        {
            seviye7_button.interactable = true;
        }
        if (seviye8 == true)
        {
            seviye8_button.interactable = true;
        }

    }
}
