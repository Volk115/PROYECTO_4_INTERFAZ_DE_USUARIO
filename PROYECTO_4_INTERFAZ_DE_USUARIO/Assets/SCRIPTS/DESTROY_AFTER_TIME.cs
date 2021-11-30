using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTROY_AFTER_TIME : MonoBehaviour
{
    private float timeDestroy = 2f;

    void Start()
    {

        //DESTRUYE EL OBJETO TRAS (2s)
        Destroy(gameObject, timeDestroy);


    }

}