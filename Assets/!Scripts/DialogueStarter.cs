using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueStarter : MonoBehaviour
{
    [Header("References")]
    public TextMeshPro text3D;       // Floating 3D text
    public GameObject characterObj;  // Character object with SpriteRenderer

    [Header("Dialogue Settings")]
    [TextArea]
    public string[] lines;           // Dialogue lines
    public float typingSpeed = 0.05f; // Typing speed per letter
    public float fadeSpeed = 2f;     // Fade in speed

    void Start()
    {
        StartCoroutine(DialogueSequence());
    }

    IEnumerator DialogueSequence()
    {
        // Make objects visible
        characterObj.SetActive(true);
        text3D.gameObject.SetActive(true);

        // Fade in character (sprite alpha)
        yield return StartCoroutine(FadeInCharacter());

        // Type all lines
        foreach (string line in lines)
        {
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(1f);
        }

        // Hide everything after dialogue
        characterObj.SetActive(false);
        text3D.gameObject.SetActive(false);
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