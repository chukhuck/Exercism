using System;
using System.Collections.Generic;
using System.Linq;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        List<(int a, int b, int c)> allTriplets = new List<(int a, int b, int c)>();

        int limit = (int) Math.Ceiling(Math.Sqrt(sum / 2 ));

        for (int m = 2; m < limit; m++)
        {
            for (int n = 1; n < m; n++)
            {
                (int a, int b, int c) primitiveTriplet = GetPrimitivePythagoreanTriplet(m, n);

                int sumOfTriplet = primitiveTriplet.a + primitiveTriplet.b + primitiveTriplet.c;

                if (sum % sumOfTriplet == 0)
                {
                    int factor = sum / sumOfTriplet;
                    if (!allTriplets.Any(triplet => triplet.a == primitiveTriplet.a * factor))
                        allTriplets.Add((primitiveTriplet.a * factor, primitiveTriplet.b * factor, primitiveTriplet.c * factor));
                }
            }
        }

        return allTriplets.OrderBy(triplet=>triplet.a);
    }

    private static (int a, int b, int c) GetPrimitivePythagoreanTriplet(int m, int n)
    {
        (int a, int b, int c) pythagoreanTriplet;
        int tempa = m * m - n * n;
        int tempb = 2 * m * n;
        pythagoreanTriplet.a = tempa < tempb ? tempa : tempb;
        pythagoreanTriplet.b = tempa < tempb ? tempb : tempa;
        pythagoreanTriplet.c = m * m + n * n;
        return pythagoreanTriplet;
    }
}

public class TripletComparer : IEqualityComparer<(int a, int b, int c)>
{
    public bool Equals((int a, int b, int c) x, (int a, int b, int c) y)
    {
        return x.a == y.a && x.b == y.b && x.c == y.c;
    }

    public int GetHashCode((int a, int b, int c) obj)
    {
        return obj.a*obj.b*obj.c;
    }
}
