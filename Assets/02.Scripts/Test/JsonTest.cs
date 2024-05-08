using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    void Start()
    {
        // 1. 유추해서 데이터를 담을 수 있는 클래스를 만들어라
        // 2. 리소스 폴더로부터 person.json 내용을 읽어와라
        TextAsset jsonText = Resources.Load<TextAsset>("person");
        
        // 3. JSON 문자열을 Person 객체로 역직렬화
        Person person = JsonUtility.FromJson<Person>(jsonText.text); 
        
        // 4. 클래스 A의 이름, 나이, 취미들을 Debug.Log로 출력
        Debug.Log($"Name: {person.Name}, Age: {person.Age}");
        foreach (var hobby in person.Hobby)
        {
            Debug.Log("Hobby: " + hobby);
        }

    }
}
