using UnityEngine;

public class TurretConfig : MonoBehaviour
{

    private TurretMovement movement;
    private BulletEmitter emitter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<TurretMovement>();
        emitter = GetComponentInChildren<BulletEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyConfiguration(
        TurretConfigOptions configOptions
    )
    {
        movement = GetComponent<TurretMovement>();
        emitter = GetComponentInChildren<BulletEmitter>();
        if (configOptions is OrbitOptions orbit) {
            movement.currentMode = TurretMovement.MovementMode.Orbit;
            movement.setOrbitRadius(orbit.orbitRadius);
            movement.setOrbitSpeed(orbit.orbitSpeed);
           
        }
        emitter.setFireRatePerSecond(configOptions.fireRatePerSecond);
    }

    // Auto-wire references when added in editor
    private void Reset()
    {
        movement = GetComponent<TurretMovement>();
        emitter = GetComponentInChildren<BulletEmitter>();
    }
}
