using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject greenGrenade;
    public GameObject yellowGrenade;
    public GameObject redGrenade;
    public GameObject enemy;
    public static int checkEnemy = 0;
    public static Dictionary<GrenadeType, int> countGrenOnScene = new Dictionary<GrenadeType, int>();
    void Start()
    {
        countGrenOnScene.Add(GrenadeType.red, 0);
        countGrenOnScene.Add(GrenadeType.green, 0);
        countGrenOnScene.Add(GrenadeType.yellow, 0);
        for (int i = 0; i < 3; i++)
        {
            NewGrenade(GrenadeType.red,redGrenade);
            NewGrenade(GrenadeType.green,greenGrenade);
            NewGrenade(GrenadeType.yellow,yellowGrenade);
            NewEnemy(enemy);
        }
        StartCoroutine(CoroutineSpawnEnemy());
        StartCoroutine(CoroutineSpawnGren(GrenadeType.red,redGrenade));
        StartCoroutine(CoroutineSpawnGren(GrenadeType.green, greenGrenade));
        StartCoroutine(CoroutineSpawnGren(GrenadeType.yellow, yellowGrenade));

    }

    void Update()
    {

    }
    public void NewGrenade(GrenadeType type,GameObject pref)
    {
        Vector3 posGren = new Vector3(Random.Range(-22, 22), 0.2f, Random.Range(-22, 22));
        GameObject newGrenade = Instantiate(pref);
        newGrenade.transform.position = posGren;
        countGrenOnScene[type]++;
    }
    public void NewEnemy(GameObject pref)
    {
        Vector3 posEnemy = new Vector3(Random.Range(-22, 22), 1f, Random.Range(-22, 22));
        GameObject newEnemy = Instantiate(pref);
        newEnemy.transform.position = posEnemy;
        checkEnemy++;
    }
    IEnumerator CoroutineSpawnEnemy()
    {
        while (true)
        {
            if (checkEnemy < 3)
            {
                yield return new WaitForSeconds(3f);
                NewEnemy(enemy);
            }
            yield return null;
        }
    }
    IEnumerator CoroutineSpawnGren(GrenadeType type,GameObject pref)
    {
        while (true)
        {
            if (countGrenOnScene[type]< 3 )
            {
                yield return new WaitForSeconds(3f);
                Debug.Log(Inventory.countGren[type]);
                NewGrenade(type,pref);
            }
            yield return null;
        }

    }
}
