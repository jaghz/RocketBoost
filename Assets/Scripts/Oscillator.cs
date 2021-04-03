using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; // current position is given by transform.position

    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } //Mathf.epsilon: smallest possible floating pt number in unity, 0 is unpredictable
        float cycles = Time.time / period; //number of cycles that have come and gone thus far = elapsed time (Time.time) / period
        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau); //going from -1 to 1

        

        movementFactor = (rawSineWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
