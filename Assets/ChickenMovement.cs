using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public AudioClip hitSound;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            Respawn();
        }
    }

    

    void Respawn()
    {
        transform.position = new Vector3(0, 1, -20); // Starting position
    }
}
