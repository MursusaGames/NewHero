using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookMenu : MonoBehaviour
{
    [SerializeField] private List<Image> btnsImage;
    [SerializeField] private List<string> magicsNames;
    [SerializeField] private Text magicNameText;
    [SerializeField] private BookScrolling scroll;


    private void Start()
    {
        ChoiceMagic(0); 
    }
    public void ChoiceMagic(int id)
    {
        for(int i = 0; i < btnsImage.Count; i++)
        {
            btnsImage[i].color = i == id ? Color.green : Color.gray;                        
        }
        magicNameText.text = magicsNames[id];
        scroll.MagicIndex = id * 3;
    }
}
