using Unity.VisualScripting;
using UnityEngine;

public class Translate : MonoBehaviour
{
    // LED-Objekt
    public GameObject led = null;

    // Material für die LED
    public Material led0 = null;
    public Material led1 = null;
    public Material led2 = null;
    public Material led3 = null;

    // Geschwindigkeit der Bewegung
    public float speed = 1.0f;

    // Rotationsgeschwindigkeit
    public float rotationSpeed = 50.0f;

    private float _elapsedTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;

        // Bewegung des Objekts entlang der Z-Achse
        if (_elapsedTime < 1)
        {
        } else if (_elapsedTime < 14)
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
        } else if (_elapsedTime < 19) { 
        } else
        {
            transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
        }
        // Rotation des Objekts um die Y-Achse
        if (_elapsedTime < 1)
        {
        } else if (_elapsedTime < 9)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        else if (_elapsedTime < 24)
        {
        }
        else
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        // LED-Animation
        if (_elapsedTime < 14)
        {
            led.GetComponent<Renderer>().material = led0;
        }
        else if (_elapsedTime < 18)
        {
            led.GetComponent<Renderer>().material = led1;
        }
        else if (_elapsedTime < 24)
        {
            led.GetComponent<Renderer>().material = led2;
        }
        else
        {
            led.GetComponent<Renderer>().material = led3;

        }
        if (_elapsedTime >= 32)
        {
            _elapsedTime = 0;
        }
    }
}
