"""
This exercise stub and the test suite contain several enumerated constants.

Since Python 2 does not have the enum module, the idiomatic way to write
enumerated constants has traditionally been a NAME assigned to an arbitrary,
but unique value. An integer is traditionally used because it’s memory
efficient.
It is a common practice to export both constants and functions that work with
those constants (ex. the constants in the os, subprocess and re modules).

You can learn more here: https://en.wikipedia.org/wiki/Enumerated_type
"""


# Score categories.
# Change the values as you see fit.
YACHT = 0
ONES = 1
TWOS = 2
THREES = 3
FOURS = 4
FIVES = 5
SIXES = 6
FULL_HOUSE = 7
FOUR_OF_A_KIND = 8
LITTLE_STRAIGHT = 9
BIG_STRAIGHT = 10
CHOICE = 11


def score(dice, category):
    if category == YACHT:
        return yacht_score(dice)
    elif category == ONES:
        return ones_score(dice)
    elif category == TWOS:
        return twos_score(dice)
    elif category == THREES:
        return threes_score(dice)
    elif category == FOURS:
        return fours_score(dice)
    elif category == FIVES:
        return fives_score(dice)
    elif category == SIXES:
        return sixes_score(dice)
    elif category == FULL_HOUSE:
        return fullhouse_score(dice)
    elif category == FOUR_OF_A_KIND:
        return fourofkind_score(dice)
    elif category == LITTLE_STRAIGHT:
        return littlestraight_score(dice)
    elif category == BIG_STRAIGHT:
        return bigstraight_score(dice)
    elif category == CHOICE:
        return choice_score(dice)
    else:
        raise ValueError('The invalid parameter.')

def ones_score(dice):
    return dice.count(1)

def twos_score(dice):
    return 2*dice.count(2)

def threes_score(dice):
    return 3*dice.count(3)

def fours_score(dice):
    return 4*dice.count(4)

def fives_score(dice):
    return 5*dice.count(5)

def sixes_score(dice):
    return 6*dice.count(6)

def choice_score(dice):
    return sum(dice)

def littlestraight_score(dice):
    return 30 if is_little_stranght(dice) else 0

def is_little_stranght(dice):
    return sorted(dice) == [1,2,3,4,5]

def bigstraight_score(dice):
    return 30 if is_big_straight(dice) else 0

def is_big_straight(dice):
    return sorted(dice) == [2,3,4,5,6]

def yacht_score(dice):
    return 50 if is_yaght(dice) else 0

def is_yaght(dice):
    return (dice == [1,1,1,1,1] or dice == [2,2,2,2,2] or dice == [3,3,3,3,3] or dice == [4,4,4,4,4]
    or dice == [5,5,5,5,5] or dice == [6,6,6,6,6])

def fullhouse_score(dice):
    return sum(dice) if is_fullhouse(dice) else 0

def is_fullhouse(dice):
    return sorted([dice.count(i+1) for i in range(6) if dice.count(i+1) != 0]) == [2, 3]

def fourofkind_score(dice):
    if dice.count(1) >= 4:
        return 4
    elif dice.count(2) >= 4:
        return 8
    elif dice.count(3) >= 4:
        return 12
    elif dice.count(4) >= 4:
        return 16
    elif dice.count(5) >= 4:
        return 20
    elif dice.count(6) >= 4:
        return 24
    else:
        return 0
