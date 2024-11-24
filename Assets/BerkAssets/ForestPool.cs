using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestPool : MonoBehaviour
{

    GameObject[] LeftForestPool; 
    GameObject[] RightForestPool;


    [SerializeField] private GameObject[] LeftForestTypes;
    [SerializeField] private GameObject[] RightForestTypes;


    // Start is called before the first frame update
    void Awake()
    {
        LeftForestPool = new GameObject[LeftForestTypes.Length * 2];
        RightForestPool = new GameObject[RightForestTypes.Length * 2];

        for (int i = 0; i < LeftForestPool.Length; i++) { 
            LeftForestPool[i] = Instantiate(LeftForestTypes[i % LeftForestTypes.Length] , transform);
            LeftForestPool[i].SetActive(false);
        
        }


        for (int j = 0; j < RightForestPool.Length; j++) {

            RightForestPool[j] = Instantiate(RightForestTypes[j % RightForestTypes.Length] , transform );
            RightForestPool[j].SetActive(false);
        
        }

        LeftForestPool.Shuffle(); 
        RightForestPool.Shuffle();


    }

    public GameObject GetLeftForest(Vector3 position) {
        
        int randNum = UnityEngine.Random.Range(0, LeftForestTypes.Length);

        for (int i = randNum;i < LeftForestPool.Length; i++)
        {
            if (!LeftForestPool[i].activeSelf) {
                LeftForestPool[i].transform.localPosition = position;
                LeftForestPool[i].SetActive(true);
                return LeftForestPool[i];
            
            }
        }

        return GetLeftForest(position);
    
    
    }

    public GameObject GetRightForest(Vector3 position)
    {

        int randNum = UnityEngine.Random.Range(0, RightForestTypes.Length);

        for (int i = randNum; i < RightForestPool.Length; i++)
        {
            if (!RightForestPool[i].activeSelf)
            {
                RightForestPool[i].transform.localPosition = position;
                RightForestPool[i].SetActive(true);
                return RightForestPool[i];

            }
        }

        return GetRightForest(position);


    }





}
