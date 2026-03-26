using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueStarter : MonoBehaviour
{
    [Header("References")]
    public TextMeshPro text3D;
    public GameObject characterObj;

    [Header("Dialogue Settings")]
    [TextArea]
    public string[] lines;
    public float typingSpeed = 0.05f;
    public float fadeSpeed = 2f;

    public float startDelay = 10f; // ⏱️ NEW: delay before dialogue

    void Start()
    {
        // 🖼️ Show immediately
        characterObj.SetActive(true);
        text3D.gameObject.SetActive(true);

        StartCoroutine(DialogueSequence());
    }

    IEnumerator DialogueSequence()
    {
        // ⏱️ Wait before starting dialogue
        yield return new WaitForSeconds(startDelay);

        // Fade in character
        yield return StartCoroutine(FadeInCharacter());

        // Type all lines
        foreach (string line in lines)
        {
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(1f);
        }

        // 🚫 REMOVED: no hiding anymore
        // characterObj.SetActive(false);
        // text3D.gameObject.SetActive(false);
    }

    IEnumerator FadeInCharacter()
    {
        SpriteRenderer sr = characterObj.GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        Color color = sr.color;
        color.a = 0;
        sr.color = color;

        while (color.a < 1)
        {
            color.a += Time.deltaTime * fadeSpeed;
            sr.color = color;
            yield return null;
        }
    }

    IEnumerator TypeLine(string line)
    {
        text3D.text = "";
        foreach (char c in line)
        {
            text3D.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}