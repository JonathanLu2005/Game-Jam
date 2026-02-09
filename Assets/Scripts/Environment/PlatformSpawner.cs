using System.Drawing;
using UnityEditor;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public float spawnInterval = 5;
    public float platformLifetime = 7;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Repeatedly calls spawn platform every spawnInterval seconds
        InvokeRepeating(nameof(SpawnPlatform), 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlatform()
    { 
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        GameObject curPlatform = Instantiate(platform, screenPosition, Quaternion.identity, transform);
        Platform platformScript = curPlatform.GetComponent<Platform>();

        if (platformScript != null )
        {
            platformScript.SetTimer(platformLifetime);
        }
    }

}
