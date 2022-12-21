using RestSharp;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using test_restsharp;
using System.Collections;
using System.Collections.Generic;

//
DateTime start = DateTime.Parse("2022-7-7");//гггг/мм/дд
DateTime end = DateTime.Parse("2022-08-08");

// Для выбора по конкретному периоду делаем цикл по этому периоду и используем простой запрос 
List<BankAPI> data = new List<BankAPI>();

for (DateTime counter = start; counter < end; counter = counter.AddDays(1))
{
    var _client = new RestClient($"https://www.nbrb.by/api/exrates/rates/451?ondate={counter.ToString("u")}&periodicity=0");
    var _request = new RestRequest("", Method.Get);
    RestResponse response = _client.Execute(_request);
    data.Add(JsonSerializer.Deserialize<BankAPI>(response.Content));
    //Console.WriteLine(counter);
}
foreach(BankAPI o in data)
{
    o.View();
}


