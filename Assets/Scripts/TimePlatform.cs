using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TimePlatform : MonoBehaviour
{
    private bool platformTemas = false;
    [SerializeField]
    private GameObject timePlatforms;
    
    IEnumerator timePlatform(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (platformTemas == true)
        {
            timePlatforms.GetComponent<TilemapCollider2D>().enabled = false;
            timePlatforms.GetComponent<TilemapRenderer>().enabled = false;
            Debug.Log("Platform Aktif Deðil!");
            StartCoroutine(timePlatformCheck(2f));
        }
    }
    IEnumerator timePlatformCheck(float delay)
    {
        yield return new WaitForSeconds(delay);

        timePlatforms.GetComponent<TilemapRenderer>().enabled = true;
        timePlatforms.GetComponent<TilemapCollider2D>().enabled = true;
        Debug.Log("Platform Aktif!");
            
        
    }
    private void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "Player")
        {
            platformTemas = true;
            StartCoroutine(timePlatform(2f));
        }

   }
    

}
