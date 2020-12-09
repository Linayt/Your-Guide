using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform P;
    public Transform E;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check devant derierre
        
        if (P.position.z > E.position.z)
        {
            Debug.Log("P est devant");
        }
        else if( P.position.z<E.position.z)
        {
            Debug.Log("P est derriere");
        }
        else
        {
            Debug.Log("aligner z");
        }


        //check droite gauche

        if (P.position.x > E.position.x)
        {
            Debug.Log("P est a droite");
        }
        else if(P.position.x < E.position.x)
        {
            Debug.Log("P est a gauche");
        }
        else
        {
            Debug.Log("aligner en x");
        }
    }
}
