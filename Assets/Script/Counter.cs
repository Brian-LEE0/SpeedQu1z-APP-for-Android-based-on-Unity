using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    float std_count = 3.99f;
    int std_round;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        std_count -= Time.deltaTime;
        std_round = (int)(Mathf.Floor(std_count));

        if (std_count <=1)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("InGame");
        }
        else
        {
            gameObject.GetComponent<Text>().text = std_round.ToString();
        }
        
    }
}
