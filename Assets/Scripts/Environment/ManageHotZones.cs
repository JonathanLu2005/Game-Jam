using UnityEngine;

public class ManageHotZones : MonoBehaviour
{
    public GameObject[] items;
    public int index = 0;
    private float interval = 10f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            items[index].SetActive(false);
            index = Random.Range(0, items.Length);
            items[index].SetActive(true);
            timer = 0f;
        }
    }
}