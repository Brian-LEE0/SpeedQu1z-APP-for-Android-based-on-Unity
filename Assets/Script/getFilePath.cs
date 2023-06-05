using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class getFilePath : MonoBehaviour
{
    string ResourcePath;
    // Start is called before the first frame update
    void Start()
    {
        ResourcePath = "file:///"+Application.persistentDataPath + "/quiz/";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetFilePath()
    {
        UnityEngine.Debug.Log(ResourcePath);
        Application.OpenURL(ResourcePath);


    }
}
