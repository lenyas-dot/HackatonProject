using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RandomSpawn : MonoBehaviour
{
    public GameObject mainObj;
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject car;
    public GameObject platform;
    public Transform allPrefabs;
    public List<GameObject> _prefabs;
    public Coroutine spawn;
    private bool flag;

    private void Start()
    {
        _prefabs = new List<GameObject>();
        spawn = StartCoroutine(SpawnCoroutine());
    }


    

    IEnumerator SpawnCoroutine()
    {
        List<GameObject> Prefabs = new List<GameObject>() { prefab, prefab2, prefab3 };
        while (true)
        { 
            
            
           

        // Рандомная область
        float x = Random.Range(-4, 4.1f);
        float y = 4;
        float z = Random.Range(20, -platform.transform.position.z+42);
        flag = false;
        Collider[] hitColliders = Physics.OverlapSphere(new Vector3(x, y, z), 4);
        foreach (var hitCollider in hitColliders)
        {
                if(hitCollider.gameObject.tag== "obstacle")
                {
                    flag = true;
                }
        }
        if(!flag)
            {
                
                    GameObject obj = Instantiate(Prefabs[Random.Range(0,3)], new Vector3(x, y, z), Quaternion.identity);
                    obj.AddComponent<Rigidbody>();
                    obj.transform.SetParent(allPrefabs);
                    _prefabs.Add(obj);
                
            }
            

            yield return new WaitForSeconds(1.0f); // Задержка
        }
    }
}