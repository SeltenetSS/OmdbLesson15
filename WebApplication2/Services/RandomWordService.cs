using System;

public class RandomWordService : IRandomWordService
{
    private readonly Random _random;

    public RandomWordService()
    {
        _random = new Random();
    }

    public string GetRandomWord(string[] words)
    {
        if (words == null || words.Length == 0)
        {
            return null;
        }

        int index = _random.Next(words.Length); 
        return words[index];
    }
}
