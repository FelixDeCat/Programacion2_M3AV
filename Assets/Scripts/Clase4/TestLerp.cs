using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLerp : MonoBehaviour
{
    [SerializeField] Renderer myRender;

    float timer = 0f;
    [SerializeField] float time_to = 1;

    Color current = new Color();

    bool flipflop = false;

    void Update()
    {
        timer = timer + 1 * Time.deltaTime;

        current = Color.Lerp
            (
            flipflop ? Color.red : Color.blue, 
            flipflop ? Color.blue : Color.red, 
            timer
            );

        myRender.material.SetColor("_Color", current);

        if (timer > time_to)
        {
            timer = 0;
            flipflop = !flipflop;
        }
    }
}
