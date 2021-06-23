using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    [SerializeField] GameObject[] growLevel;
    [SerializeField] float growTime;
    [SerializeField]
    float time = 0f;
    bool grew = false;

    public float GrowTime { get => growTime; set => growTime = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!grew)
        {
            time += Time.deltaTime;

            if (time > growTime)
            {
                grew = true;
                ChangeActiveObejct(growLevel.Length - 1);
                GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                var idx = time / (growTime / (growLevel.Length - 1));
                ChangeActiveObejct((int)idx);
            }
        }
    }

    void ChangeActiveObejct(int _index)
    {
        foreach (var obj in growLevel)
        {
            obj.SetActive(false);
        }

        growLevel[_index].SetActive(true);
    }
}
