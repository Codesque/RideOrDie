using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{

    ForestPool pool;
    [SerializeField] private bool isItLeftForestGenerator = false;
    List<GameObject> ActiveForests = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        pool = GameObject.FindFirstObjectByType<ForestPool>();
        ActiveForests.Add(GetForest(transform.position));
        ActiveForests.Add(GetForest(transform.position + Vector3.down * 12f));
    }


    public GameObject GetForest(Vector3 position) { if (isItLeftForestGenerator) return pool.GetLeftForest(position); return pool.GetRightForest(position); }


    // Update is called once per frame
    void Update()
    {
        for (int i = ActiveForests.Count-1; i > -1; i--) { 
        
            Vector3 currentPos = ActiveForests[i].gameObject.transform.position;
            currentPos.y -= RoadGenerator.EnvironmentSpeed * Time.deltaTime;
            if (currentPos.y <= -12f) {

                ActiveForests[i].SetActive(false);
                ActiveForests.RemoveAt(i);
                Vector3 refPoint = ActiveForests[0].transform.position;
                ActiveForests.Add(GetForest(refPoint + Vector3.up * 12f));

            }

            else ActiveForests[i].transform.position = currentPos;
        
        }



    }
}
