using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeInputScript : MonoBehaviour
{
    public InputField InputTime;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chg()
    {
        Timer.Std_TIME = float.Parse(InputTime.text);
        InputTime.placeholder.GetComponent<Text>().text = "제한시간 : " + Timer.Std_TIME.ToString();
        Debug.Log(Timer.Std_TIME);
    }

}
