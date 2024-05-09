using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using MongoDB.Bson;
using System.Linq;
using static UnityEngine.ParticleSystem;
using System.Data;

// 1. 하나만을 보장
// 2. 어디서든 쉽게 접근 가능
public class ArticleManager : MonoBehaviour
{
    // 게시글 리스트
    private List<Article> _articles = new List<Article>();
    public List<Article> Articles => _articles;

    private IMongoCollection<BsonDocument> _articleCollection;
    public static ArticleManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        Init();
        FindAll();
    }

    // 몽고
    public void Init()
    {
        // 몽고 DB로부터 article 조회
        // 1. 몽고DB 연결
        string connectionString = "mongodb+srv://jms5966:jms5966@cluster0.juowh4x.mongodb.net/";
        var mongoclient = new MongoClient(connectionString);
        // 2. 특정 데이터베이스 연결
        IMongoDatabase sampleDB = mongoclient.GetDatabase("metavers");
        // 3. 특정 콜렉션 연결
        _articleCollection = sampleDB.GetCollection<BsonDocument>("articles");

    }

    public void FindAll()
    {
        // 4. 모든 문서 읽어오기
        List<BsonDocument> alldata = _articleCollection.Find(new BsonDocument()).ToList();

        // 5. 읽어온 문서 만큼 New Article()해서 데이터 채우고
        _articles.Clear();
        foreach (var data in alldata)
        {
            //    _articles에 넣기
            _articles.Add(new Article()
            {
                ArticleType = (ArticleType)(int)data["ArticleType"],
                Name = data["Name"].ToString(),
                Content = data["Content"].ToString(),
                Like = (int)data["Like"],
                WriteTime = DateTime.Parse(data["WriteTime"].ToString())
            });
        }
    }
    public void FindNotice()
    {

        // 4. 공지 문서 읽어오기
        List<BsonDocument> alldata = _articleCollection.Find(data => data["ArticleType"] == (int)ArticleType.Notice).ToList();

        // 5. 읽어온 문서 만큼 New Article()해서 데이터 채우고
        _articles.Clear();
        foreach (var data in alldata)
        {
            //    _articles에 넣기
            _articles.Add(new Article()
            {
                ArticleType = (ArticleType)(int)data["ArticleType"],
                Name = data["Name"].ToString(),
                Content = data["Content"].ToString(),
                Like = (int)data["Like"],
                WriteTime = DateTime.Parse(data["WriteTime"].ToString())
            });
        }
    }
}