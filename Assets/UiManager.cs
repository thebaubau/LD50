using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject generalCanvas;
    public GameObject startPanel;
    public GameObject winPanel;
    public TextMeshProUGUI winningQuote;
    public GameObject background;

    public Sprite[] bgSprites;
    public bool mouseBought = false;

    private Animator canvasAnimator;
    private SpriteRenderer bgSprite;

    private string[] quotes = new string[]
    {
        "They say procrastinators are perfectionists. Well, I say better to be late and perfect than on time and average",
        "Warning: Tackling a difficult project after returning to work from a holiday weekend can cause dizziness, extreme resentment, and low self-esteem.",
        "Postponement is the first step in acknowledging that something at hand needs to get done... eventually.",
        "Wouldn't it be great if money were as easy to make as it is to spend?",
        "If you feel guilty about doing nothing at the end of the day, you have procrastinated improperly. Begin again tomorrow with a better attitude.",
        "If you search \"psychology of procrastination\" online, you'll notice a lot of experts have too much time on their hands."
    };

    private static UiManager instance;

    public static UiManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UiManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        canvasAnimator = generalCanvas.GetComponent<Animator>();
        bgSprite = background.GetComponent<SpriteRenderer>();
    }

    public void SetBgSprite(Sprite sprite)
    {
        bgSprite.sprite = sprite;
    }

    public void AddMouse()
    {
        mouseBought = true;
        bgSprite.sprite = bgSprites[0];
    }

    public void Win()
    {
        StartCoroutine(WinGame());
    }

    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(3);
        startPanel.SetActive(false);
        winPanel.SetActive(true);
        winningQuote.text = quotes[UnityEngine.Random.Range(0, quotes.Length - 1)];
        canvasAnimator.Play("Win");
        generalCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;

        yield return null;
    }
}
