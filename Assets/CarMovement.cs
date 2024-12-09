using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction = Vector3.forward;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
