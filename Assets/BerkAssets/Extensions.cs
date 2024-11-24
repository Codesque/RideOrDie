using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class Extensions { 

    public static void Shuffle<T>(this T[] arr) {

        

        for (int i = 0; i < arr.Length; i++) { 
            

            int randNum = UnityEngine.Random.Range(0, arr.Length);
            T bucket = arr[randNum]; 
            arr[randNum] = arr[i];
            arr[i] = bucket;
        }



    }



}


