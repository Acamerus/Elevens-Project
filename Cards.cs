namespace Elevens;

public class Card
{
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }
    
    public Card(Rank rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
    }
    
    public int GetValue()
    {
        switch (Rank)
        {
            case Rank.Ace: return 1;
            case Rank.Two: return 2;
            case Rank.Three: return 3;
            case Rank.Four: return 4;
            case Rank.Five: return 5;
            case Rank.Six: return 6;
            case Rank.Seven: return 7;
            case Rank.Eight: return 8;
            case Rank.Nine: return 9;
            case Rank.Ten: return 10;
            case Rank.Jack:
            case Rank.Queen:
            case Rank.King: return 10;
            default: return 0;
        }
    }
    
    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}