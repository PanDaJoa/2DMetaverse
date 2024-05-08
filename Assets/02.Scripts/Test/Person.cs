using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;

[Serializable]
public class Person
{
    public string Name;
    public int Age;
    public string[] Hobby;
}
