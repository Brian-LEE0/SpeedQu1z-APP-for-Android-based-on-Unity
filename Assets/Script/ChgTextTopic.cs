using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChgTextTopic : MonoBehaviour
{
    
    public Text t;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void textChange(string inp)
    {
        t.GetComponent<Text>().text = inp;
    }
}
