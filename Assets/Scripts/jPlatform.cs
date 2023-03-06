using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jPlatform : MonoBehaviour
{
    [SerializeField]
    private float jumpPower = 20f;
    private void OnCollisionEnter2D(Collision2D temas)
    {
            
            Rigidbody2D rb = temas.collider.GetComponent<Rigidbody2D>();

            if(rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpPower;
                rb.velocity = velocity;
            }
        
    }
}
