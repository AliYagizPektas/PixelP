using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform firstPos, secondPos;
    [SerializeField] private float mSpeed;
    private Vector3 nextPos;
    
    private void Start()
    {
        nextPos = firstPos.position;
    }

    
    private void Update()
    {
        if(transform.position == firstPos.position)
        {
            nextPos = secondPos.position;
        }
        if(transform.position == secondPos.position)
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
    }
    private void OnCollisionExit2D(Collision2D temas)
    {
        if (temas.transform.tag == "Player")
            temas.collider.transform.SetParent(null);
    }
}
