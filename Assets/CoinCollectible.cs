using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    public AudioClip coinSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            GameManager.instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
