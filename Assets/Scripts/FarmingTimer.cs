using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmingTimer : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] Text timerText;
    [SerializeField] new BoxCollider2D collider;

    bool isGrew = false;

    // Update is called once per frame
    void Update()
    {
        if (!isGrew)
        {
            timer -= Time.deltaTime;
            timerText.text = ((int)timer).ToString();
        
            if (timer < 0)
            {
                collider.enabled = true;
                isGrew = true;
                timerText.text = "^^";
            }

        }
    }    
}
