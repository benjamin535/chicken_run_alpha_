using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public float spawnInterval = 10f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCar();
            timer = -2;
        }
    }

    void SpawnCar()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-20, 20), 8f, transform.position.z);
        GameObject car = Instantiate(carPrefab, spawnPosition, Quaternion.identity);

        // Set the direction of the car to move backward
        CarMovement carMovement = car.GetComponent<CarMovement>();
        if (carMovement != null)
        {
            carMovement.direction = Vector3.back; // Set direction to opposite
        }
    }
}
