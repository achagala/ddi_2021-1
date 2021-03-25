using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Prac_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] nums = {3,12,30,68,100};
        int target = 80;

        int[] output = SumaDos(nums, target);

        PrintArray(output);
    }

    public int[] SumaDos(int[] nums, int target)
    {
        int aux;
        int[] output = new int [2];

        if(target > nums[0])
        {
            for(int i=0 ; i< (nums.Length - 1) ; i++)
            {
                aux = target - nums[i];
                int x = Array.BinarySearch(nums, aux);

                if(x > 0)
                {
                    output[0] = i;
                    output[1] = x;

                    i = nums.Length;
                }
            }
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
