using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{

    RoadwayPool roadwayPool;
    public List<GameObject> ActiveRoads = new List<GameObject>();
    public static float EnvironmentSpeed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        roadwayPool = GameObject.FindFirstObjectByType<RoadwayPool>();
        //EnvironmentSpeed = 0f;
        ActiveRoads.Add(roadwayPool.GetRoadway(transform.position));
        ActiveRoads.Add(roadwayPool.GetRoadway(transform.position + Vector3.down * 12f));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = ActiveRoads.Count - 1; i > -1; i--)
        {
            Vector3 currentPos = ActiveRoads[i].transform.position;
            currentPos += Vector3.down * EnvironmentSpeed * Time.deltaTime;
            if (currentPos.y <= -12f) { 
                
                ActiveRoads[i].SetActive(false);
                ActiveRoads.RemoveAt(i);
                Vector3 refPoint = ActiveRoads[0].transform.position;
                GameObject newRoad = roadwayPool.GetRoadway(refPoint + Vector3.up * 12f);
                ActiveRoads.Add(newRoad);
            }
            else ActiveRoads[i].transform.position = currentPos;




        }
    }
}
