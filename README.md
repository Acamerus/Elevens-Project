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

