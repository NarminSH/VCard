using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

HttpClient client = new();
CardService cardService = new();


var result = JObject.Parse(await client.GetStringAsync("https://randomuser.me/api?result=50"));
var name = (Uri.EscapeUriString(result["results"][0]["name"]["first"].ToString()));
var surname = (Uri.EscapeUriString(result["results"][0]["name"]["last"].ToString()));
var phone = (Uri.EscapeUriString(result["results"][0]["phone"].ToString()));
var email = (Uri.EscapeUriString(result["results"][0]["email"].ToString()));
var gender = (Uri.EscapeUriString(result["results"][0]["gender"].ToString()));
var country = (Uri.EscapeUriString(result["results"][0]["location"]["country"].ToString()));
var city = (Uri.EscapeUriString(result["results"][0]["location"]["city"].ToString()));
Console.WriteLine(name + " " + surname + phone + email + country + city);


var obj = new Card
{
    First = name,
    Last = surname,
    Phone = phone,
    Email = email,
    Country = country,
    City = city,
    Gender = gender

};

var res = await cardService.CreateAsync(obj);
Console.WriteLine(res);



