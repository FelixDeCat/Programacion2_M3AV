using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutines : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitAndPrint());
    }

    IEnumerator WaitAndPrint()
    {
        print("Inicia Corrutina");
        //
        //
        //
        //
        yield return null; // esperear al proximo frame
        print("Paso 1 frame desde que inicie la corrutina");
        //
        ///
        //
        yield return new WaitForSeconds(1f);
        print("Paso 1 segundo desde que inicie la corrutina");

        yield return new WaitForSeconds(1f);
        print("Paso 2 segundo desde que inicie la corrutina");

        yield return new WaitForSeconds(1f);
        print("Paso 3 segundo desde que inicie la corrutina");

        yield return new WaitForSeconds(1f);
        print("Paso 4 segundo desde que inicie la corrutina");
        //
        //

        while (true)
        {
            yield return null;

            print("1 frame");

        }

    }

}
