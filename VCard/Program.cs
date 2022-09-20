using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

HttpClient client = new();
CardService cardService = new();


try
{
    var results = JObject.Parse(await client.GetStringAsync("https://randomuser.me/api?results=50"));
    for (int i = 0; i < results["results"].ToArray().Length; i++)
    {
        var first = results["results"][i]["name"]["first"].ToString();
        var last = results["results"][i]["name"]["last"].ToString();
        var email = results["results"][i]["email"].ToString();
        var phone = results["results"][i]["phone"].ToString();
        var country = results["results"][i]["location"]["country"].ToString();
        var city = results["results"][i]["location"]["city"].ToString();
        var gender = results["results"][i]["gender"].ToString();


        Card obj = new()
        {
            First = first,
            Last = last,
            Email = email,
            City = city,
            Country = country,
            Phone = phone,
            Gender = gender
        };
        var res = await cardService.CreateAsync(obj);
        Console.WriteLine(res);
    }

    return;

}
catch (Exception ex)
{
    Console.WriteLine("There was a problem connecting to a server, Please try again!");
    return;
}







