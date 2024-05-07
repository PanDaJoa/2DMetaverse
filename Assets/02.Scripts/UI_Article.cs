using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// Article 객체를 보여주는 게임 오브젝트
public class UI_Article : MonoBehaviour
{
    public Image           ProfileImageUI;         // 프로필 이미지
    public TextMeshProUGUI NameTextUI;             // 글쓴이
    public TextMeshProUGUI ContentTextUI;          // 글 내용
    public TextMeshProUGUI LikeTextUI;             // 좋아요 개수
    public TextMeshProUGUI WriteTimeTextUI;        // 글 쓴 날짜/시간
    public void Init(Article article)
    {
        NameTextUI.text = article.Name;
        ContentTextUI.text = article.Content;
        LikeTextUI.text = $"{article.Like}";
        WriteTimeTextUI.text = $"{article.WriteTime}";
    }
}
