using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class CarRevealContrl : MonoBehaviour
{

    public GameObject[] CarPaintItem;

    public GameObject PaintIBg;

    public GameObject[] CarPaintBtnItem;

    public Vector2[] CarPaintBtnPos;

    public GameObject[] ModelCarBody;

    public Material[] ModelCarPint_Mate;

    public GameObject[] Btn_OnSelect;

    IEnumerator Start()
    {

        foreach (var item in CarPaintItem)
        {
            item.transform.DOScale(0,0);
        }
 
        PaintIBg.GetComponent<RectTransform>().DOSizeDelta(new Vector2(0, 160),0);
        PaintIBg.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-334,155),0);


        for (int i = 0; i < CarPaintBtnItem.Length; i++)
        {
            CarPaintBtnItem[i].GetComponent<RectTransform>().DOAnchorPos(CarPaintBtnPos[i],1).SetEase(Ease.Linear);
            yield return new WaitForSeconds(0.3f);
        }
    }



    public void OpenCarPaint()
    {
        CarPaintBtnItem_Contrl(0);

        PaintIBg.GetComponent<RectTransform>().DOSizeDelta(new Vector2(760, 160), 0.8f);
        PaintIBg.GetComponent<RectTransform>().DOAnchorPos(new Vector2(45, 155),0.8f);

        StartCoroutine("CarPaintItem_Effect_Open");
    }
    IEnumerator CarPaintItem_Effect_Open()
    {
        foreach (var item in CarPaintItem)
        {
            item.transform.DOScale(1,0.5f).SetEase(Ease.InCubic);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator CarPaintItem_Effect_Close()
    {
        foreach (var item in CarPaintItem)
        {
            item.transform.DOScale(0, 0.5f).SetEase(Ease.InCubic);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OpenWheelHubBtn()
    {
        CarPaintBtnItem_Contrl(1);

        PaintIBg.GetComponent<RectTransform>().DOSizeDelta(new Vector2(0, 160), 0.8f).SetDelay(1f);
        PaintIBg.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-334, 155), 0.8f).SetDelay(1f);

        StartCoroutine("CarPaintItem_Effect_Close");
    }


    void CarPaintBtnItem_Contrl(int index)
    {
        foreach (var item in CarPaintBtnItem)
        {
            item.GetComponent<Button>().interactable = true;
        }
        CarPaintBtnItem[index].GetComponent<Button>().interactable = false;
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Color_CarBlueBtn()
    {
        foreach (var item in Btn_OnSelect)
        {
            item.SetActive(false);
        }
        Btn_OnSelect[0].SetActive(true);

        foreach (var item in ModelCarBody)
        {
            item.GetComponent<Renderer>().material = ModelCarPint_Mate[1];
        }
    }

    public void Color_CarRedBtn()
    {
        foreach (var item in Btn_OnSelect)
        {
            item.SetActive(false);
        }
        Btn_OnSelect[1].SetActive(true);

        foreach (var item in ModelCarBody)
        {
            item.GetComponent<Renderer>().material = ModelCarPint_Mate[0];
        }
    }
    public void Color_CarHuiBtn()
    {
        foreach (var item in Btn_OnSelect)
        {
            item.SetActive(false);
        }
        Btn_OnSelect[2].SetActive(true);

        foreach (var item in ModelCarBody)
        {
            item.GetComponent<Renderer>().material = ModelCarPint_Mate[2];
        }
    }
}
