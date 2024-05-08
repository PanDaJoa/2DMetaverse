using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MongoExample02 : MonoBehaviour
{
    void Start()
    {
        string connectionString = "mongodb+srv://jms5966:jms5966@cluster0.juowh4x.mongodb.net/";
        MongoClient mongoclient = new MongoClient(connectionString);
        IMongoDatabase sampleDB = mongoclient.GetDatabase("sample_mflix");
        var movieCollection = sampleDB.GetCollection<BsonDocument>("movies");

        // 읽기, 쓰기, 수정, 삭제 
        // 읽기 : Find 메서드
        // Finds 메서드: 컬렉션 담겨 있는 도큐먼트를 조회하는 메서드다.
        // 사용 빈도가 압도적으로 높다. -> 그만큼 중요하다!
        // SQL: Select Query(질의) Language
        BsonDocument data = movieCollection.Find(new BsonDocument()).FirstOrDefault();
        Debug.Log(data["plot"]);

        // BsonDoucment 는 (binary) json을 표현하는 자료형이다.
        // new BsonDocument(); - -> { }

        // 2. 도큐먼트 10개 읽기
        List<BsonDocument> datas = movieCollection.Find(new BsonDocument()).Limit(10).ToList();
        foreach (var d in datas)
        {
            Debug.Log(d["title"]);
        }

        // 3. 2002 년도에 개봉한 영화 찾기
        // 3-1. Bson '값으로 쿼리'
        BsonDocument filter = new BsonDocument();
        filter["year"] = 2002;
        var data2002 = movieCollection.Find(filter).Limit(5).ToList();

        // 3-2. '필터 쿼리'를 사용한 방식
        var filter2 = Builders<BsonDocument>.Filter.Eq("year", 2002);
        var data20022 = movieCollection.Find(filter2).Limit(5).ToList();
    }
}
