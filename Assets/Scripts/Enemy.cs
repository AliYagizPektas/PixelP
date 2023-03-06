using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject replay_button;
    [SerializeField] private Transform firstPos, secondPos;
    [SerializeField] private float mSpeed;
    private Vector3 nextPos;
    public AudioSource audio_death;

    private void Start()
    {
        nextPos = firstPos.position;
    }
    private void Update()
    {
        if (transform.position == firstPos.position)
        {
            nextPos = secondPos.position;
        }
        if (transform.position == secondPos.position)
        {
            nextPos = firstPos.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, mSpeed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(firstPos.position, secondPos.position);
    }
    private void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.transform.tag == "Player")
            temas.collider.transform.SetParent(transform);
        if (temas.transform.tag == "Player")
        {
            audio_death.Play();
            Time.timeScale = 0;
            replay_button.SetActive(true);
        }

    }
    private void OnCollisionExit2D(Collision2D temas)
    {
        if (temas.transform.tag == "Player")
            temas.collider.transform.SetParent(null);
    }

}
