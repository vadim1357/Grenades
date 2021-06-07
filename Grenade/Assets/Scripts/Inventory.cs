using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    public Text countRedGren;
    public Text countGreenGren;
    public Text countYellowGren;
    public static Inventory Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<Inventory>();
            }
            return instance;
        }
    }
    public static Dictionary<GrenadeType, int> countGren = new Dictionary<GrenadeType, int>();
    private void Awake()
    {
        countGren.Add(GrenadeType.red, 0);
        countGren.Add(GrenadeType.green, 0);
        countGren.Add(GrenadeType.yellow, 0);
    }
    void Update()
    {
        countRedGren.text = countGren[GrenadeType.red].ToString();
        countGreenGren.text = countGren[GrenadeType.green].ToString();
        countYellowGren.text = countGren[GrenadeType.yellow].ToString();
    }
    public void AddGrenade(GrenadeType type)
    {
        countGren[type]++;
    }
    public void UseGrenade(GrenadeType type)
    {
        countGren[type]--;
    }
    public bool CheckGren(GrenadeType type)
    {
        if(countGren[type] > 0)
        {
            return true;
        }
        return false;
    }
    public int CountGrenType(GrenadeType type)
    {
        return countGren[type];
    }
}
public enum GrenadeType
{
    red = 1,
    green = 2,
    yellow = 3
}