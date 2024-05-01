using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIcon : MonoBehaviour
{
    public static GameObject PlayerIcon;

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public GameObject b6;
    public GameObject b7;
    public GameObject b8;
    public GameObject b9;
    public GameObject b10;
    public GameObject b11;

    private Color32 gray = new Color32(220,220,220,255);


    public void Start(){
        b1.GetComponent<Image>().color = gray;
        b2.GetComponent<Image>().color = gray;
        b3.GetComponent<Image>().color = gray;
        b4.GetComponent<Image>().color = gray;
        b5.GetComponent<Image>().color = gray;
        b6.GetComponent<Image>().color = gray;
        b7.GetComponent<Image>().color = gray;
        b8.GetComponent<Image>().color = gray;
        b9.GetComponent<Image>().color = gray;
        b10.GetComponent<Image>().color = gray;
        b11.GetComponent<Image>().color = gray;
    }

    public void selectIconButton(GameObject button){

        
        b1.GetComponent<Image>().color = gray;
        b2.GetComponent<Image>().color = gray;
        b3.GetComponent<Image>().color = gray;
        b4.GetComponent<Image>().color = gray;
        b5.GetComponent<Image>().color = gray;
        b6.GetComponent<Image>().color = gray;
        b7.GetComponent<Image>().color = gray;
        b8.GetComponent<Image>().color = gray;
        b9.GetComponent<Image>().color = gray;
        b10.GetComponent<Image>().color = gray;
        b11.GetComponent<Image>().color = gray;

        button.GetComponent<Image>().color = new Color32(150,150,150,255);
        PlayerIcon = button;

    }
}
