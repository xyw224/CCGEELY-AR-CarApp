using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public void OnMoveDown()
    {
        CarManager.isMove = true;
    }

    public void OnMoveUp()
    {
        CarManager.isMove = false;
    }

    public void OnBackDown()
    {
        CarManager.isBack = true;
    }

    public void OnBackUp()
    {
        CarManager.isBack = false;
    }

    public void OnZDown()
    {
        CarManager.isZ = true;
    }
    public void OnZUp()
    {
        CarManager.isZ = false;
    }

    public void OnYDown()
    {
        CarManager.isY = true;
    }

    public void OnYUp()
    {
        CarManager.isY = false;
    }
}
