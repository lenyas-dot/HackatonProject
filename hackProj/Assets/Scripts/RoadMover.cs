using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMover : MonoBehaviour
{
    public GameObject roadPlatform;
    public float _speed = 5f;
    public GameObject objectToCreate;
    public GameObject allPlatforms;
    public List<GameObject> platforms;
    public Transform platformsAll;
    public Coroutine roadCoroutine;

    private List<GameObject> _swapElements(List<GameObject> listPlatforms)
    {
        List<GameObject> platformList = listPlatforms;
            GameObject element = platformList[0];
            platformList[0] = platformList[1];
            platformList[1] = element;
        return platformList;
    }
    private void Start()
    {
        platforms = new List<GameObject>();
        roadCoroutine = StartCoroutine(RoadCoroutine());
    }

    
    IEnumerator RoadCoroutine()
    {
        bool isExist = false;
        bool isExist2 = false;
        platforms.Add(roadPlatform);
        while (true)
        {
            platforms[0].transform.Translate(0, 0, _speed * Time.deltaTime);
            
            if (platforms[0].transform.position.z <= -480  && !isExist)
            {
                Vector3 vectorPos = new Vector3()
                {
                    x = 0,
                    y = 0,
                    z = 41.499f

                };
                Debug.Log(vectorPos.z);
                GameObject newPlatform = Instantiate(objectToCreate, vectorPos, Quaternion.identity);
                platforms.Add(newPlatform);
                platforms = _swapElements(platforms);
                isExist = true;
                newPlatform.transform.localScale.Set(0, 0, 110);
                Debug.Log(newPlatform.transform.position.z);
                newPlatform.transform.SetParent(platformsAll);
                Destroy(platforms[1].gameObject);
            }
            if (platforms[0].transform.position.z <= -5 && !isExist2 && isExist)
            {
                platforms.RemoveAt(1);
                isExist2 = true;
                
            }
            if (isExist && isExist2)
            {
                isExist = false;
                isExist2 = false;
            }
            yield return null;
        }
    }


}
