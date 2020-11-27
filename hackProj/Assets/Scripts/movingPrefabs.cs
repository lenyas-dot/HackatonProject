using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPrefabs : MonoBehaviour
{
    public GameObject AllPlatforms;
    public GameObject AllPrefabs;
    public GameObject MainCar;
    public Coroutine enumerator;
    public bool isStop;
    private void Start()
    {
         enumerator = StartCoroutine(PrefabCoroutine());
    }
    private void Update()
    {
        if (isStop)
        {
            new WaitForSeconds(5f);
            enumerator = StartCoroutine(PrefabCoroutine());
        }
    }
         
    IEnumerator PrefabCoroutine()
    {
        while (true)
        {
            isStop = false;
            for (int i = 0; i < AllPrefabs.gameObject.transform.childCount; i++)
            {
                AllPrefabs.transform.GetChild(i).SetParent(AllPlatforms.transform.GetChild(0));

            }
            if (AllPlatforms.transform.GetChild(0).transform.position.z <= -440)
            {
                isStop = true;
                StopCoroutine(enumerator);
            }
            yield return new WaitForSeconds(0.5f);
        }

        
    }
}
