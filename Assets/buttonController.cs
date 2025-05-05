using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PointerEventsController : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler {

    public string buttonDescription="";
    BattleManager battleManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //display
        //Debug.Log("In " + buttonDescription);
        battleManager.textWindowUI(buttonDescription);
    }

    public void setDescription(string str){
        buttonDescription = str;
    }

    public void setBattleManager(BattleManager bm){
        battleManager =bm;
    }
    public void OnPointerExit(PointerEventData eventData)
    { 
        //close display
        //Debug.Log("out");
        battleManager.closeTextWinowUI();
    }
   
}