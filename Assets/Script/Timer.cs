using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    int point;
    public Text text;
    public static float Std_TIME = 90f;
    public static float left_TIME;
    public Button bt;

    // Start is called before the first frame update
    void Start()
    {
        left_TIME = Std_TIME;
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // 
            SceneManager.LoadScene("MainScene");
        }
        timerGO();
    }

    public void scoreUp()
    {
        point++;
        text.text = "¸ÂÈù °¹¼ö : " + point.ToString() + " °³" ;
    }

    public void scoreDw()
    {
        if(point > 0)
        {
            point--;
            text.text = "¸ÂÈù °¹¼ö : " + point.ToString() + " °³";
        }
    }

    public void timerGO()
    {
        if(bt.IsActive())
        {
            left_TIME -= Time.deltaTime;
        }      
        GetComponent<Text>().text = left_TIME.ToString("F2") + " ÃÊ";
    }


}
