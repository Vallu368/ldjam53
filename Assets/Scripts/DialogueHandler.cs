using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField] private float FadeSpeed = 20.0f;
    [SerializeField] private int RolloverCharacterSpread = 10;
    public bool textIsActive = false;
    void Awake()
    {
        text = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        text.gameObject.SetActive(false);
    }

    public void ChangeText(string newText)
    {
        text.text = newText;
    }

    public void EnableText()
    {
        if (!textIsActive)
        {
            StartCoroutine(FadeInText());
            Debug.Log("enabled text");
        }
        else Debug.Log("TEXT ALREADY GOING PLS WAIT");
    }
    IEnumerator FadeInText()
    {
        textIsActive = true;
        text.gameObject.SetActive(true);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        text.ForceMeshUpdate();

        TMP_TextInfo textInfo = text.textInfo;
        Color32[] newVertexColors;

        int currentCharacter = 0;
        int startingCharacterRange = currentCharacter;
        bool isRangeMax = false;

        while (!isRangeMax)
        {
            int characterCount = textInfo.characterCount;

            byte fadeSteps = (byte)Mathf.Max(1, 255 / RolloverCharacterSpread);

            for (int i = startingCharacterRange; i < currentCharacter + 1; i++)
            {
                if (!textInfo.characterInfo[i].isVisible) continue;

                int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

                newVertexColors = textInfo.meshInfo[materialIndex].colors32;

                int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                byte alpha = (byte)Mathf.Clamp(newVertexColors[vertexIndex + 0].a + fadeSteps, 0, 255);

                newVertexColors[vertexIndex + 0].a = alpha;
                newVertexColors[vertexIndex + 1].a = alpha;
                newVertexColors[vertexIndex + 2].a = alpha;
                newVertexColors[vertexIndex + 3].a = alpha;

                if (alpha == 255)
                {
                    startingCharacterRange += 1;

                    if (startingCharacterRange == characterCount)
                    {
                       // Debug.Log("max char count");
                        yield return new WaitForSeconds(1f);
                        text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

                        yield return new WaitForSeconds(1.0f);

                        text.ForceMeshUpdate();

                        text.gameObject.SetActive(false);
                        textIsActive = false;
                    }
                }
            }

            text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

            if (currentCharacter + 1 < characterCount) currentCharacter += 1;

            yield return new WaitForSeconds(0.25f - FadeSpeed * 0.01f);

        }
    }



}
