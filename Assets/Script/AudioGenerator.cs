using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cor;
    public GameObject pas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCor()
    {
        GameObject prefab = Instantiate(cor);
        Destroy(prefab, 2);
    }

    public void PlayPas()
    {
        GameObject prefab = Instantiate(pas);
        Destroy(prefab, 2);
    }
}
