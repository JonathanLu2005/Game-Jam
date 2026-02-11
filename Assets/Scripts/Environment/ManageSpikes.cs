using UnityEngine;
using System.Collections;


public class ManageSpikes : MonoBehaviour
{
    public GameObject[] reals;
    public GameObject[] fakes;
    public int index = 0;
    private float interval = 5f;
    private float timer = 0f;
    private bool now = true;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval && now)
        {
            interval = Random.Range(5f, 10f);
            fakes[index].SetActive(false);
            reals[index].SetActive(true);
            timer = 0f;
            now = false;
        }
        else if (timer >= interval && !now)
        {
            reals[index].SetActive(false);
            index = Random.Range(0, reals.Length);
            interval = 1f;
            fakes[index].SetActive(true);
            timer = 0f;
            now = true;
        }
    }



}