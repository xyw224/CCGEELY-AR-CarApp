using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class MainMenuContrl : MonoBehaviour
{
    public GameObject MainMenuBg2;
    public GameObject MainMenuBg3;

    public GameObject[] MainMenuBtn;
    public GameObject[] MainMenuBtn_Text;

    void Start()
    {
        StartCoroutine("IEMainMenuContrl");
    }

    IEnumerator IEMainMenuContrl()
    {
       
        foreach (var item in MainMenuBtn)
        {
            item.transform.GetComponent<Image>().DOFade(0, 0).SetEase(Ease.Linear);
        }
        foreach (var item in MainMenuBtn_Text)
        {
            item.transform.GetComponent<Text>().DOFade(0, 0).SetEase(Ease.Linear);
        }

        MainMenuBg2.GetComponent<Image>().DOFade(0, 0).SetEase(Ease.Linear);
        MainMenuBg3.GetComponent<Image>().DOFade(0, 0).SetEase(Ease.Linear);

        yield return new WaitForSeconds(0.5f);

        MainMenuBg2.GetComponent<Image>().DOFade(1, 1).SetEase(Ease.Linear);
        MainMenuBg3.GetComponent<Image>().DOFade(1, 1).SetEase(Ease.Linear);

        foreach (var item in MainMenuBtn)
        {
            item.transform.GetComponent<Image>().DOFade(1, 1).SetEase(Ease.Linear);
        }
        foreach (var item in MainMenuBtn_Text)
        {
            item.transform.GetComponent<Text>().DOFade(1, 1).SetEase(Ease.Linear);
        }
    }

    public void OpenAR_ARCarMenu()
    {
        SceneManager.LoadScene("CarMenu");
    }

    public void OpenAR_CarShowMenu()
    {
        SceneManager.LoadScene("CarPaint_Quality_Very Low");
    }
}
