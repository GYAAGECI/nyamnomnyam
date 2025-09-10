using UnityEngine;

public class ColorButton : MonoBehaviour{
    public GameManager gm;
    public string myColor;

    public void ClickMe(){
        gm.ClickButton(myColor);
    }
}