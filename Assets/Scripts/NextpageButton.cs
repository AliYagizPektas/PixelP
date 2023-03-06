using UnityEngine;
using UnityEngine.UI;

public class NextpageButton : MonoBehaviour
{
    [SerializeField] private Button nextPage1b;
    private void Start()
    {
        nextPage1b.interactable = false;
    }
    private void Update()
    {
        if(ParaController.sayi >= 19f)
        {
            nextPage1b.interactable = true;
        }
        else
        {
            nextPage1b.interactable = false;
        }
    }
}
