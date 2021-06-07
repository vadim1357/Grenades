using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Canvas _canvas;
    public Image bar;
    private void Start()
    {
        _canvas.worldCamera = Camera.main;
    }
   public void SetHP(float curHP, float maxHP)
    {
        float p = curHP / maxHP;
        Vector3 scale = bar.transform.localScale;
        scale.x = p;
        bar.transform.localScale = scale;
    }
}
