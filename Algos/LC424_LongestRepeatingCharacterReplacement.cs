// Your C# code here
public class LC424_LongestRepeatingCharacterReplacement
{
    // Your code goes here
    public void LongestRepeatingCharacterReplacement()
    {
        Console.WriteLine("****** LongestRepeatingCharacterReplacement *********");

        Console.WriteLine(CharacterReplacement("AAABABB", 1));
    }

    public static void run_LongestRepeatingCharacterReplacement()
    {
        LC424_LongestRepeatingCharacterReplacement obj = new LC424_LongestRepeatingCharacterReplacement();
        obj.LongestRepeatingCharacterReplacement();
    }

    public static int CharacterReplacement(string s, int k)
    {
        Dictionary<char, int> store = new Dictionary<char, int>();

        int left = 0;
        int right = 0;
        int len = 0;

        for (; right < s.Length; right++)
        {
            if (store.ContainsKey(s[right]))
            {
                store[s[right]] += 1;
            }
            else
            {
                store[s[right]] = 1;
            }

            while (right - left + 1 - findMax(store) > k)
            {
                store[s[left]] -= 1;
                if (store[s[left]] == 0) 
                    store.Remove(s[left]);

                left = left + 1;
            }
            len = Math.Max(len, right - left+1);
        }
        return len;
    }

    public static int findMax(Dictionary<char, int> store)
    {
        int max = 0;

        foreach (var v in store)
        {
            max = Math.Max(v.Value, max);
        }

        return max;
    }
}
