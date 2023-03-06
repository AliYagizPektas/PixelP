using UnityEngine;

public class TutorialSign : MonoBehaviour
{
    [SerializeField]
    private TextMesh myText;
    [SerializeField]
    private string tutorialText;

    private void Start()
    {
        myText.text = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        myText.text = tutorialText;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        myText.text = null;
    }
}
