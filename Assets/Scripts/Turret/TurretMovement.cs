using UnityEngine;

public class TurretMovement : MonoBehaviour
{

    public enum MovementMode
    {
        Orbit,
        Spin,
    }
    [Header("Settings")]
    private Transform centerPoint;    // What we orbit around
    private float orbitRadius = 13f;    // Distance from center
    private float orbitSpeed = 50f;    // Degrees per second

    

    [Header("Rotation")]
    public bool faceCenter = true;

    private float angle;

    public MovementMode currentMode;

    void Start()
    {
        GameObject originObj = GameObject.FindGameObjectWithTag("Origin");
        centerPoint = originObj.transform;
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
        switch (currentMode)
        {
            case MovementMode.Orbit: 
                Orbit() ;
                break;
            default: 
                Orbit();
                break;
        }
    }

    public void setOrbitRadius(float f)
    {
        orbitRadius = f;
    }
    public void setOrbitSpeed(float f)
    {
        orbitSpeed = f;
    }

    private void Orbit()
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
