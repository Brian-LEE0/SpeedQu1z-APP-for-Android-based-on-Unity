using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgChanger : MonoBehaviour
{
    public GameObject bg1;
    public GameObject bg2;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickbutton()
    {
        if (loadTopic.level % 2 == 0)
        {
            bg1.SetActive(false);
            bg2.SetActive(true);
        }
        else
        {
            bg2.SetActive(false);
            bg1.SetActive(true);
        }
    }
}
