using System;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            OrderedBag<int> bag = new OrderedBag<int>();
            int counter = 0;

            foreach (var cookie in cookies)
            {
                bag.Add(cookie);
            }

            int currentMinSweatness = bag.GetFirst();

            while (currentMinSweatness < k && bag.Count > 1)
            {
                int leastCookie = bag.RemoveFirst();
                int secondCookie = bag.RemoveFirst();

                int combined = leastCookie + (2 * secondCookie);

                bag.Add(combined);
                counter++;
                currentMinSweatness = bag.GetFirst();
            }

            return currentMinSweatness < k ? -1 : counter;
        }
    }
}
