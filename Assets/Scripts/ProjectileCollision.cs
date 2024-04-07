using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nesne player'a veya zemine çarptıgında yok olur
        if (collision.gameObject.tag == "Enemy" ||collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
