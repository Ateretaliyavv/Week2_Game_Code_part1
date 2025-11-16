using UnityEngine;
using System;


public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.right; // Movement direction
    [SerializeField] private float length = 7f;   // Movement length
    [SerializeField] private float speed = 3f;    // Movement speed


    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position; // Store starting position
    }

    void Update()
    {
        float x = Time.time * speed;
        float offset = Mathf.Cos(x) * length; // Calculate offset using cosine for smooth oscillation
        transform.position = startPos + direction.normalized * offset;
    }
}