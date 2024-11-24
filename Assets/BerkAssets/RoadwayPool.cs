using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadwayPool : MonoBehaviour
{

    public GameObject[] roadTypes;
    [SerializeField] private GameObject[] roadPool;


    // Start is called before the first frame update
    void Awake()
    {
        roadPool =  new GameObject[roadTypes.Length * 10];
        for (int i = 0; i < roadPool.Length; i++) {
            roadPool[i] = Instantiate(roadTypes[i % roadTypes.Length] , transform);
            roadPool[i].SetActive(false);
        
        }

        roadPool.Shuffle();

    }


    public GameObject GetRoadway(Vector3 position) {

        int randIdx = UnityEngine.Random.Range(0, roadPool.Length);
        

        for (int i = randIdx; i < roadPool.Length; i++)
            if (!roadPool[i].activeSelf) {

                roadPool[i].transform.position = position;
                roadPool[i].SetActive(true);
                return roadPool[i];
            }

        return GetRoadway(position);
    
    }


}
