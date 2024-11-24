using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CarAI {


    public float HowMuchCarPerPeriod;
    public float HowManyPeriod;
    public float PeriodTime;
    public bool[] WhichRoadsAllowed = new bool[]{ true ,true , true , true , true };
    public List<GameObject> CarSprites = new List<GameObject>();


}




[CreateAssetMenu(fileName ="EnemyCarObstacleAI" ,menuName = "EnemyAI/Create New Obstacle Period")]
public class CarAIScriptableObject : ScriptableObject
{
        
    public List<CarAI> CarAIList;
}
