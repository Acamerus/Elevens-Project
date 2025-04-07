namespace Elevens;

public class Deck
{
    private List<Card> cards = new List<Card>();
    
    public Deck()
    {
        // Create a standard 52-card deck
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(rank, suit));
            }
        }
    }
    
    public int Count() => cards.Count;
    
    public bool IsEmpty() => cards.Count == 0;
    
    public Card TakeTopCard()
    {
        if (IsEmpty())
            return null;
            
        Card topCard = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return topCard;
    }
    
    public void Shuffle()
    {
        Random random = new Random();
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int randomIndex = random.Next(0, i + 1);
            
            Card temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }
}