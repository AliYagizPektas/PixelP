using UnityEngine;

public class Para : MonoBehaviour
{
    internal bool paraCheck;
    private void Start()
    {     
        ParaController.sayi = PlayerPrefs.GetInt(nameof(ParaController.sayi));
    }
    private void OnTriggerEnter2D(Collider2D temas)
    {

        if (temas.gameObject.tag == "Para")
        {
            Destroy(temas.gameObject);
            ParaController.sayi += 1;
            PlayerPrefs.SetInt(nameof(ParaController.sayi), ParaController.sayi);


        }


    }
}
