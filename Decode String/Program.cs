using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Decode_String
{
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      string s = "100[leetcode]"; //  3[a]2[bc] // 3[a2[c]] // 2[abc]3[cd]ef // 100[leetcode]
      Solution sol = new Solution();
      var answer = sol.DecodeString(s);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public string DecodeString(string s)
    {
      Stack<string> stk = new Stack<string>();
      foreach (char c in s)
      {
        // Step 1 - when we see a opening bracket we push to stack
        if (c != ']')
        {
          stk.Push(c.ToString());
        }
        // Step 2 - when we see a ']' bracket we will pop until see see a '['
        else
        {
          // Step 3 - Pop from stack until we see '['
          // here we are poping all the alphabets
          string str = "";
          while (stk.Count > 0 && stk.Peek() != "[")
          {
            str = stk.Pop() + str;
          }
          // we need to pop one more time to pop the "["
          stk.Pop();

          // Step 4 - pop the digits
          string k = "";
          while (stk.Count > 0 && stk.Peek().All(char.IsDigit))
          {
            k = stk.Pop() + k;
          }
          string subStr = string.Concat(Enumerable.Repeat(str, Convert.ToInt32(k)));
          stk.Push(subStr);
        }
      }

      string result = "";
      while(stk.Count > 0)
      {
        result = stk.Pop() + result;
      }

      return result;
    }
  }
}
