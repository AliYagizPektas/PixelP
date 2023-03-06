using UnityEngine;

public class KnockBackPlatform : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    private void OnCollisionEnter2D(Collision2D temas)
    {
        {
            if (temas.gameObject.tag == "Player")
            {
                playerController.KBforce = 3f;
                playerController.KBcounter = playerController.KBTotalTime;
                if (temas.transform.position.x <= transform.position.x)
                {
                    playerController.KnocbackFromRight = true;
                }
                if (temas.transform.position.x > transform.position.x)
                {
                    playerController.KnocbackFromRight = false;
                }
            }
            
        }
    }
}
