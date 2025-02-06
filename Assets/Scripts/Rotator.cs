using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Rotationsgeschwindigkeit
    public float rotationSpeed = 50.0f;

    // Rotationsgeschwindigkeit
    public float rotationSpeedRelative = 50.0f;

    // Referenz zum zentralen Objekt
    public Transform centralObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (centralObject != null)
        {
            // Berechne die Position des Kindobjekts relativ zum zentralen Objekt
            transform.RotateAround(centralObject.position, Vector3.up, rotationSpeedRelative * Time.deltaTime);
        }

        // Rotation des Objekts um die Z-Achse
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
