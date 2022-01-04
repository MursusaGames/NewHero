using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScrolling : MonoBehaviour
{
    
    private int panCount;    
    public List<GameObject> panPrefabs = new List<GameObject>();      
    GameObject[] instPans;
    Vector2[] panPos;    
    public bool isScrolling;
    public ScrollRect scrollRect;  

    private void Start()
    {
        panCount = panPrefabs.Count;       
        panPos = new Vector2[panCount];
        instPans = new GameObject[panCount];

        for (int i = 0; i < panCount; i++)
        {
            instPans[i] = Instantiate(panPrefabs[i], transform, false);                       
            if (i == 0) continue;
            var tmpY = instPans[i - 1].transform.localPosition.y - instPans[i - 1].GetComponent<RectTransform>().sizeDelta.y;
            instPans[i].transform.localPosition = new Vector2( instPans[i].transform.localPosition.x, tmpY);
            panPos[i] = -instPans[i].transform.localPosition;
        }
    }
}
