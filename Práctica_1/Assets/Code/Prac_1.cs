using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prac_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] numbers = {8,1,2,2,3};
        int[] output = Numbers(numbers);

        PrintArray(output);
    }

    private int[] Numbers(int[] list)
    {
        int count = 0;
        int max = list.Length;
        int[] output = new int[max];

        for(int i = 0 ; i < max ; i++)
        {
            for(int j = 0 ; j < max ; j++)
            {
                if(list[j] < list[i])
                {
                    count++;
                }
            }
            output[i] = count;
            count = 0;
            
        }
        return output;
    }

    private void PrintArray(int[] array)
    {
        foreach (var i in array)
        {
            Debug.Log(i);
        }
    }
}
