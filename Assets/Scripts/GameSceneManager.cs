using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameObject blackScreen;
    int fasterFadeSpeed = 1000;
    public int fadeSpeed = 5;
    private void Update()
    {

    }

    public void FadeOutandIn()
    {
        StartCoroutine(FadeOutFadeIn());
    }
    public void End()
    {
        StartCoroutine(FadeOut());
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
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        blackScreen.SetActive(false);
    }
    public IEnumerator FadeOutFadeIn()
    {
        Debug.Log("started fading");
        blackScreen.SetActive(true);
        Color objectColor = blackScreen.GetComponent<Image>().color;
        float fadeAmount;


        while (blackScreen.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (fasterFadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackScreen.GetComponent<Image>().color = objectColor;
            yield return null;
        }

        while (blackScreen.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackScreen.GetComponent<Image>().color = objectColor;
            yield return null;
        }
        Debug.Log("jobs done");
        blackScreen.SetActive(false);


    }

}
