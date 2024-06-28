using System;

public static class EventGenerator
{
    private static readonly Random Random = new Random();

    public static List<string> GenerateEvent(int batchNumber = 1)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var randomString = new char[50];
        var events = new List<string>();
        for (int i = 0; i < batchNumber; i++)
        {
            for (int j = 0; j < randomString.Length; j++)
            {
                randomString[j] = chars[Random.Next(chars.Length)];
            }

            events.Add($"{new string(randomString)}");
        }

        return events;
    }
}
