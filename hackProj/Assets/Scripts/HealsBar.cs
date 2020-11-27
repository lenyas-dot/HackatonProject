using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealsBar : MonoBehaviour
{
    

    public float maxHeals;
    public Texture HealsTexture;

    private float BarWidth;
    public float realHeals;
    private float TextureWidth;


    void Start()
    {
        BarWidth = Screen.width / 4;
        //realHeals = maxHeals;
        TextureWidth = BarWidth;
    }




    void OnGUI()
    {
        var res = realHeals / maxHeals*100;
        // GUI.Box(new Rect(10, 10, BarWidth, 40), res + "%");
        //GUI.Box()
 
        if (HealsTexture != null && TextureWidth > 0)
        {
            GUI.DrawTexture(new Rect(10, 30, TextureWidth, 15), HealsTexture, ScaleMode.ScaleAndCrop, true, 10.0f);
        }
        GUI.Box(new Rect(10, 26, BarWidth, 19), res + "%");
    }



    public void calculatedHeals(float dmg)
    {
        if (realHeals - dmg > 0)
        {
            realHeals = realHeals - dmg;
            TextureWidth = BarWidth * (realHeals / maxHeals);
        }
        else
        {
            realHeals = 0.0f;
            TextureWidth = 0.1f;
        }
    }
}
