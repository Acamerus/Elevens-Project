// ElevensGame

// -deck: Deck
// -table: List<Card>
// -const Table_Size: int

// +ElevensGame()
// +Play()
// -PrintTable()
// -HasValidMove() :: Bool
// -IsValidPair(i : int, j: int) :: bool
// -HasValidFaceSEt() :: bool
// -RemoveCards(indices: int[])
// -RefillTable()


namespace Elevens;

public class ElevensGame
{
    private readonly Deck deck;
    private readonly List<Card> table;
    private const int TABLE_SIZE = 9;

    public ElevensGame()
    {
        // 1. Initialize the deck and table
        deck = new Deck();
        table = new List<Card>();
        
        // 2. Shuffle the deck
        deck.Shuffle();
        
        // 3. Deal initial 9 cards to the table
        RefillTable();
    }

    public void Play()
    {
        Console.WriteLine("Welcome to Elevens!");
        Console.WriteLine("Find pairs that sum to 11 or sets of J-Q-K to remove cards.");
        Console.WriteLine("Press Enter to start...");
        Console.ReadLine();
        
        bool gameOver = false;
        
        while (!gameOver)
        {
            // Clear the console at the start of each turn to keep it clean
            Console.Clear();
            
            PrintTable();
            
            if (!HasValidMove())
            {
                Console.WriteLine("No valid moves available. Game over!");
                gameOver = true;
                continue;
            }
            
            Console.WriteLine("\nEnter card indices to select (separated by spaces), or 'q' to quit:");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "q")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
            
            try
            {
                // Parse input for card indices
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] indices = parts.Select(p => int.Parse(p) - 1).ToArray(); // Convert to 0-based indices
                
                // Check if valid selection
                if (indices.Length == 2)
                {
                    if (IsValidPair(indices[0], indices[1]))
                    {
                        RemoveCards(indices);
                        RefillTable();
                        Console.WriteLine("Cards removed successfully!");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid pair! Cards must sum to 11.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                }
                else if (indices.Length == 3)
                {
                    // Check if all are face cards
                    bool allFaceCards = indices.All(i => 
                        i >= 0 && i < table.Count && 
                        (table[i].Rank == Rank.Jack || 
                         table[i].Rank == Rank.Queen || 
                         table[i].Rank == Rank.King));
                    
                    // Check if exactly one of each face card type
                    bool hasJack = indices.Any(i => i >= 0 && i < table.Count && table[i].Rank == Rank.Jack);
                    bool hasQueen = indices.Any(i => i >= 0 && i < table.Count && table[i].Rank == Rank.Queen);
                    bool hasKing = indices.Any(i => i >= 0 && i < table.Count && table[i].Rank == Rank.King);
                    
                    if (allFaceCards && hasJack && hasQueen && hasKing)
                    {
                        RemoveCards(indices);
                        RefillTable();
                        Console.WriteLine("Face cards removed successfully!");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection! Need one each of Jack, Queen, and King.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please select either 2 cards (for sum of 11) or 3 face cards (J-Q-K).");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter valid card numbers.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            
            // Check if game is over (no cards left in deck and no valid moves)
            if (deck.Count() == 0 && table.Count < TABLE_SIZE && !HasValidMove())
            {
                Console.Clear();
                PrintTable();
                Console.WriteLine("No more cards in deck and no valid moves. Game over!");
                gameOver = true;
            }
        }
        
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }

    private void PrintTable()
    {
        Console.WriteLine("\nCurrent Table:");
        Console.WriteLine("--------------");
        
        for (int i = 0; i < table.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {table[i]} (Value: {table[i].GetValue()})");
        }
        
        Console.WriteLine($"Cards remaining in deck: {deck.Count()}");
    }

    private bool HasValidMove()
    {
        // Check for pairs that sum to 11
        for (int i = 0; i < table.Count; i++)
        {
            for (int j = i + 1; j < table.Count; j++)
            {
                if (IsValidPair(i, j))
                {
                    return true;
                }
            }
        }
        
        // Check for J-Q-K sets
        return HasValidFaceSet();
    }

    private bool IsValidPair(int i, int j)
    {
        if (i < 0 || i >= table.Count || j < 0 || j >= table.Count)
            return false;
            
        return table[i].GetValue() + table[j].GetValue() == 11;
    }

    private bool HasValidFaceSet()
    {
        bool hasJack = table.Any(card => card.Rank == Rank.Jack);
        bool hasQueen = table.Any(card => card.Rank == Rank.Queen);
        bool hasKing = table.Any(card => card.Rank == Rank.King);
        
        return hasJack && hasQueen && hasKing;
    }

    private void RemoveCards(int[] indices)
    {
        // Sort indices in descending order to remove from end first
        // This prevents index shifting issues
        Array.Sort(indices);
        Array.Reverse(indices);
        
        foreach (int index in indices)
        {
            if (index >= 0 && index < table.Count)
            {
                table.RemoveAt(index);
            }
        }
    }

    private void RefillTable()
    {
        // Fill table back up to TABLE_SIZE if possible
        while (table.Count < TABLE_SIZE && deck.Count() > 0)
        {
            table.Add(deck.TakeTopCard());
        }
    }
}