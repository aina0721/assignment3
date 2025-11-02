using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameObject TitleImage;

    public GameObject game_manager;

    [SerializeField] private RectTransform testPanel;
    [SerializeField] private Vector2 rectSize;

    [SerializeField] private Vector2 targetSize = new Vector2(412.5f, 567);
    [SerializeField] private float speed = 0.5f;
    private float t;

    public static float limitTime; // カウントダウンタイム
    public Text TimerText; // 表示用テキストUI

    void Start()
    {
        limitTime = 5; // カウントダウン開始秒数をセット

        testPanel = GetComponent<RectTransform>();

        testPanel.sizeDelta = new Vector2(275, 378);
        rectSize = testPanel.sizeDelta; // サイズ取得

        game_manager = GameObject.Find("InputField");
    }
    void Update()
    {
        limitTime -= Time.deltaTime;

        if (limitTime < 0)
        {
            limitTime = 0;
            TitleImage.SetActive(false);
        }

        TimerText.text = limitTime.ToString("F0"); // 残り時間を整数で表示

        if (t < 1f && limitTime == 0 &&
            !game_manager.GetComponent<GameManager>().CorrectText.activeSelf)
        {
            t += Time.deltaTime * speed;
            testPanel.sizeDelta = Vector2.Lerp(rectSize, targetSize, t);
        }
        else if (game_manager.GetComponent<GameManager>().CorrectText.activeSelf)
        {
            testPanel.sizeDelta = new Vector2(275, 378);
            rectSize = testPanel.sizeDelta;
            t = 0f;
        }

        if (testPanel.sizeDelta == new Vector2(412.5f, 567))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
