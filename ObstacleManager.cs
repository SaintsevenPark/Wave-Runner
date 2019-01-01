using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public GameObject playerObj;
    public GameObject[] ObstaclesArr;

    int playerDistanceIndex = -1;
    int obstacleCout;
    int obstacleIndex = 0;
    int distanceToNext = 50;
    
    // Start is called before the first frame update
    void Start()
    {
        obstacleCout = ObstaclesArr.Length;
        InstantiateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        int PlayerDistance = (int)(playerObj.transform.position.y / (distanceToNext));
        // 플레이너의 y값을 25로 나줘서 1,2,3,4,5, 이런시으로 표시해줌
        Debug.Log("Player Distance : " + PlayerDistance);

        if(playerDistanceIndex != PlayerDistance)
        {
            InstantiateObstacle();
            playerDistanceIndex = PlayerDistance;
        }
    }

    public void InstantiateObstacle()
    {
        int RandomInt = Random.Range(0, obstacleCout);
        GameObject newObstacle = Instantiate(ObstaclesArr[RandomInt], new Vector3(0, obstacleIndex * distanceToNext), Quaternion.identity);
        newObstacle.transform.SetParent(transform);
        obstacleIndex++;
    }

}
