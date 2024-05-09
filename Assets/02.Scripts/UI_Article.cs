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
        WriteTimeTextUI.text = GetTimeString(article.WriteTime);
    }

    private string GetTimeString(DateTime dateTime)
    {
        TimeSpan TimeSpan = DateTime.Now - dateTime;
        if (TimeSpan.TotalMinutes < 1)         // 1분 이내 -> 방금 전
        {
            return "방금 전";
        }
        else if (TimeSpan.TotalHours < 1)      // 1시간 이내 -> n분전
        {
            return $"{TimeSpan.Minutes}분 전";
        }
        else if (TimeSpan.TotalDays < 1)       // 하루 이내 -> n시간 전
        {
            return $"{TimeSpan.Hours}시간 전";
        }
        else if (TimeSpan.TotalDays < 7)       // 7일 이내 -> n일 전
        {
            return $"{TimeSpan.Days}일 전";
        }
        else if (TimeSpan.TotalDays < 7 * 4)   // 4주 이내 -> n주 전
        {
            return $"{TimeSpan.Days / 7}주 전";
        }
        else
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
    }

}

