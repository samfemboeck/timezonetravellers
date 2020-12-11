using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float FadeSpeed;
    public Image _image;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponentInChildren<Image>();
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true)
    {
        Color color = _image.color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (_image.color.a < 1)
            {
                fadeAmount = color.a + (FadeSpeed * Time.deltaTime);
                color = new Color(color.r, color.g, color.b, fadeAmount);
                _image.color = color;
                yield return null;
            }
        }
        else
        {
            while (_image.color.a > 0)
            {
                fadeAmount = color.a - (FadeSpeed * Time.deltaTime);
                color = new Color(color.r, color.g, color.b, fadeAmount);
                _image.color = color;
                yield return null;
            }
        }
    }
}
