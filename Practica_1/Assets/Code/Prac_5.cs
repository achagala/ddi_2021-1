using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Prac_5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] numbers = {12, 345, 2, 6, 7896};

        int a = IsPair(numbers);

        Debug.Log("Numeros pares = " + a);


        int[] nums = {2,2,10,5,5,10,7};

        int b = IsDifferent(nums);

        Debug.Log("Numero diferente = " + b);
    }

    int IsPair(int[] input)
    {
        int output = 0;

        for(int i = 0 ; i<input.Length ; i++)
        {
            if((Math.Floor(Math.Log10(input[i]) + 1) % 2) == 0)
            {
                output++;
            }
        }

        return output;
    }

    int IsDifferent(int[] input)
    {
        int output = input[0];

        for(int i = 1 ; i<input.Length ; i++)
        {
            output = output ^ input[i];
        }

        return output;
    }
}
