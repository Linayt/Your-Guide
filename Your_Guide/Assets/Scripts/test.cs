using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject g1;
    public GameObject g2;
    // Start is called before the first frame update
    void Start()
    {
        if (g1 == g2)
        {
            Debug.Log("Ca marche");
        }
        else
        {
            Debug.Log("Ca marche pas");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
