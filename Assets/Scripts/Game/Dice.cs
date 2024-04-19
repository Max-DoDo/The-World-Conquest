using System;
using UnityEngine;
public class Dice : MonoBehaviour{

    System.Random random = new System.Random();

    public int roll(){
        return random.Next(1, 7);
    }

    public int[] roll(int times){
        int[] points = new int[times];

        for(int i = 0;i < points.Length;i++){
            points[i] = random.Next(1, 7);
        }

        for(int i = 0;i < points.Length;i++){
            for(int c = 1;c< points.Length;c++){
                if(points[i] < points[c]){
                    int temp = points[i];
                    points[i] = points[c];
                    points[c] = temp;
                }
            }
        }

        Debug.Log(points);

        return points;
    }
}