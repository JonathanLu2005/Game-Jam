using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public abstract class TurretConfigOptions {
    public Vector2 position;
    public float fireRatePerSecond;
}

class OrbitOptions : TurretConfigOptions
{
    public float orbitRadius;
    public float orbitSpeed;

    public OrbitOptions(Vector2 position, float orbitRadius, float orbitSpeed, float fireRatePerSecond)
    {
        this.position = position;
        this.orbitRadius = orbitRadius;
        this.orbitSpeed = orbitSpeed;
        this.fireRatePerSecond = fireRatePerSecond;
    }
}

public class TurretSystem : MonoBehaviour
{
    public static TurretSystem Instance;
    public TurretConfig turretPrefab;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Demonstrate, spawn a turret when the t key is pressed
        //if (Keyboard.current.tKey.wasPressedThisFrame)
        //{
        //    Spawn(
        //       new OrbitOptions(new Vector2(0, 0), 11f, 20f, 1)
        //    );
        //}
    }

    public TurretConfig Spawn(
        TurretConfigOptions configOptions
    )
    {
        TurretConfig turret = Instantiate(turretPrefab, configOptions.position, Quaternion.identity);
        turret.ApplyConfiguration(configOptions);
        return turret;
    }

    public void Release(TurretConfig turret) { 
        
        turret.gameObject.SetActive(false);

    }
}
