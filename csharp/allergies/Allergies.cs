using System;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private Allergen allergens;

    public Allergies(int mask)
    {
        allergens = (Allergen)mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return (allergens & allergen) != 0; 
    }

    public Allergen[] List()
    {
        return Enumerable.
                    Range(0, 8).
                    Select(i=> 1 << i).
                    Where(i => IsAllergicTo((Allergen)i)).
                    Cast<Allergen>().
                    ToArray();
    }
}