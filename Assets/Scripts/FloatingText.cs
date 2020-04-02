using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public Animator anim;
    [SerializeField]private Text scoreText;

    // Start is called before the first frame update
    void OnEnable()
    {
        scoreText = anim.GetComponent<Text>();
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
    }

    public void SetText(string text)
    {
        scoreText.text = text;
    }
}
