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
