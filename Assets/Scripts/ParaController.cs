using UnityEngine;
using UnityEngine.UI;

public class ParaController : MonoBehaviour
{
    [SerializeField] internal static int sayi = 0;
    [SerializeField] private Text sayac;

    private void Start()
    {
        sayac = GetComponent<Text>();
    }
    private void Update()
    {
        sayac.text = sayi.ToString();
    }
}
