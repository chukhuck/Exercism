using System;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        switch(category) {
        case YachtCategory.Ones: 
            return OnesScore(dice);
        case YachtCategory.Twos: return TwosScore(dice);
        case YachtCategory.Threes:  return ThreesScore(dice);
        case YachtCategory.Fours:  return FoursScore(dice);
        case YachtCategory.Fives:  return FivesScore(dice);
        case YachtCategory.Sixes:  return SixesScore(dice);
        case YachtCategory.Choice:  return ChoiceScore(dice);
        case YachtCategory.FourOfAKind:  return FourOfKindScore(dice);
        case YachtCategory.FullHouse:  return FullHouseScore(dice);
        case YachtCategory.LittleStraight:  return LittleStraightScore(dice);
        case YachtCategory.BigStraight:  return BigStraightScore(dice);
        case YachtCategory.Yacht:  return YachtScore(dice);
        default: throw new Exception("You need to implement this function.");
        };
    }

public static int OnesScore(int[] dice)
{
    return dice.Count(i => i == 1);
}

public static int TwosScore(int[] dice){
    return 2*dice.Count(i => i == 2);
}

public static int ThreesScore(int[] dice){
    return 3*dice.Count(i => i == 3);
}

public static int FoursScore(int[] dice){
    return 4*dice.Count(i => i == 4);
}

public static int FivesScore(int[] dice){
    return 5*dice.Count(i => i == 5);
}

public static int SixesScore(int[] dice){
    return 6*dice.Count(i => i == 6);
}

public static int ChoiceScore(int[] dice){
    return dice.Sum();
}

public static int LittleStraightScore(int[] dice){
    return IsLittleStranght(dice) ? 30 : 0; 
}

public static bool IsLittleStranght(int[] dice){
    return dice.OrderBy(i=>i).SequenceEqual(new int[]{1,2,3,4,5});
}
public static int BigStraightScore(int[] dice){
    return IsBigStraight(dice) ? 30 : 0;
}
public static bool IsBigStraight(int[] dice){
    return dice.OrderBy(i=>i).SequenceEqual(new int[]{2,3,4,5,6});
}
public static int YachtScore(int[] dice){
    return IsYaght(dice) ? 50 : 0;
}
public static bool IsYaght(int[] dice){
    return  dice.SequenceEqual(new int[]{1,1,1,1,1}) ||
            dice.SequenceEqual(new int[]{2,2,2,2,2}) ||
            dice.SequenceEqual(new int[]{3,3,3,3,3}) ||
            dice.SequenceEqual(new int[]{4,4,4,4,4}) ||
            dice.SequenceEqual(new int[]{5,5,5,5,5}) ||
            dice.SequenceEqual(new int[]{6,6,6,6,6}) ;
}

public static int  FullHouseScore(int[] dice){
    return IsFullhouse(dice) ? dice.Sum() : 0;
}

public static bool IsFullhouse(int[] dice){
    return Enumerable.Range(1,6)
                    .Select(i => dice.Count(j=>j == i))
                    .Where(i => i != 0)
                    .OrderBy(i =>i)
                    .SequenceEqual(new int[]{2,3});
}

public static int FourOfKindScore(int[] dice){
    if (dice.Count(i => i == 1) >= 4)
        return 4;
    else if (dice.Count(i => i == 2) >= 4)
        return 8;
    else if (dice.Count(i => i == 3) >= 4)
        return 12;
    else if (dice.Count(i => i == 4) >= 4)
        return 16;
    else if (dice.Count(i => i == 5) >= 4)
        return 20;
    else if (dice.Count(i => i == 6) >= 4)
        return 24;
    else
        return 0;
}
}

