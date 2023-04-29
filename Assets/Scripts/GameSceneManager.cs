using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public GameObject blackScreen;
    public int fadeSpeed = 5;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(FadeOut());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(FadeIn());
        }
    }
    private void Awake()
    {
        blackScreen = GameObject.Find("BLACKSCREEN");
        blackScreen.SetActive(false);
    }
    public IEnumerator FadeOut()
    {
        blackScreen.SetActive(true);
        Color objectColor = blackScreen.GetComponent<Image>().color;
        float fadeAmount;


            while (blackScreen.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackScreen.GetComponent<Image>().color = objectColor;
                yield return null;
            }
            Debug.Log("jobs done");
        }
    public IEnumerator FadeIn()
    {
        blackScreen.SetActive(true);
        Color objectColor = blackScreen.GetComponent<Image>().color;
        float fadeAmount;


        while (blackScreen.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackScreen.GetComponent<Image>().color = objectColor;
            yield return null;
        }
        Debug.Log("jobs done");
    }

}
