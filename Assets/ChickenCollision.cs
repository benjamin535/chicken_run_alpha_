using UnityEngine;

public class ChickenCollision : MonoBehaviour
{
    public Transform respawnPoint;  // Optional, assign if you have a respawn system
    public AudioClip coinSound;     // Optional, assign a sound clip for coin collection
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Print a message whenever any collision occurs
        Debug.Log("Collision detected with: " + other.gameObject.name);

        // Check if the collided object is on the "Coin" layer
        if (other.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            Debug.Log("Coin collected!");

            // Increase score
            FindObjectOfType<ScoreManager>().AddScore(1);

            // Play sound if available
            if (coinSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(coinSound);
            }

            // Destroy the coin object
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Collided with non-coin object: " + other.gameObject.name);
        }
    }
}
