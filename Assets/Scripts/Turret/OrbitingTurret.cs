using UnityEngine;

public class OrbitingTurret : MonoBehaviour
{
    [Header("Orbit Settings")]
    public Transform centerPoint;    // What we orbit around
    public float orbitRadius = 3f;    // Distance from center
    public float orbitSpeed = 90f;    // Degrees per second

    [Header("Rotation")]
    public bool faceCenter = true;

    private float angle;

    void Start()
    {
        if (centerPoint == null)
        {
            Debug.LogError("OrbitingTurret2D: No center point assigned!");
            enabled = false;
            return;
        }

        // Set starting angle from current position
        Vector2 offset = transform.position - centerPoint.position;
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
    }

    void Update()
    {
        // Move along the orbit
        angle += orbitSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;

        Vector2 orbitOffset = new Vector2(
            Mathf.Cos(rad),
            Mathf.Sin(rad)
        ) * orbitRadius;

        transform.position = (Vector2)centerPoint.position + orbitOffset;

        // Face the center
        if (faceCenter)
        {
            Vector2 direction = (Vector2)centerPoint.position - (Vector2)transform.position;

            // Make the sprite's UP axis point toward the center
            transform.up = direction;
        }
    }
}
