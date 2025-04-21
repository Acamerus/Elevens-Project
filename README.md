Summary: This is a simple console terminal card game, Elevens. The goal is to remove pairs of cards that add up to 11. You play with a standard 52-card deck, and only the number cards (ace through 10) are used to make pairs that total 11. Face cards (Jack, Queen, King) are removed in sets of one Jack, one Queen, and one King. You win by clearing all the cards from the Current Table and Deck.

Challenges: Certain logics were hard to implement in the Elevens card game, specifically having one set of each Face Card. This was mostly due to my unfamiliarity with Elevens as a card game, and was resolved with a quick search.

How to play: 
1. Clone or download the file to your machine.
2. Make sure to have or install .NET 9.
3. Open C# Project in VS Code(preferably) and run.
4. You will be displayed with a simple instruction in-game. To make a pair selection (1-9 the current hand), enter two numbers (1 5); for a face-only selection, enter three numbers (1 3 5).


Overview UML

ElevensGame

-deck: Deck
-table: List<Card>
-const Table_Size: int

+ElevensGame()
+Play()
-PrintTable()
-HasValidMove() :: Bool
-IsValidPair(i : int, j: int) :: bool
-HasValidFaceSEt() :: bool
-RemoveCards(indices: int[])
-RefillTable()

Deck

-cards: List<Card>

+Deck()
+Count() :: int
+IsEmpty() :: bool
+TakeTopCard() :: Card
+Shuffle()

Card

-suit: Suit
-Rank: Rank

+Card(rank: Rank, suit: suit)
+GetValue() :: int
+ToString() :: string

Enums Rank

Enum Suit

![image](https://github.com/user-attachments/assets/f592c830-d2a5-400e-b436-1663f47b9825)

