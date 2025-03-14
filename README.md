Will create through unity for GUI extra credit

Class: Card

-Suit: String
-Rank: int

+Cards(suit, Rank)
+IsFaceCard (): bool
+ToString (): String

Class Deck

-Cards: Card []
-Delete: Card []

+Shuffle()
+DrawCard(): Card
+IsEmpty(): bool
+ReplaceCards (useCards: Card[])



Class: Elevens

-deck: Deck
-hand: Card[]
-lose: bool

+InitializaeGame()
+CheckForElevens: bool
+CheckValidMove: bool
+RemoveMatchedCard ()
+ValidateHandCount
+IsGameOver() bool
