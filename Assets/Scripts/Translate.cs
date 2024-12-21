using UnityEngine;

public class Translate : MonoBehaviour
{
    // Geschwindigkeit der Bewegung
    public float speed = 5.0f;

    // Rotationsgeschwindigkeit
    public float rotationSpeed = 50.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Bewegung des Objekts entlang der Z-Achse
        transform.Translate(0, 0, speed * Time.deltaTime, Space.World);

        // Rotation des Objekts um die Y-Achse
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
