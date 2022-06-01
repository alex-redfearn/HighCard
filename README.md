# High Card

## Implementation
### Project
Split up classes into their own files but kept them all in the same namespace for simplicity. Decided to split the add and shuffle cards logic and implement the Fisher-Yates Shuffle. Although this comes at a slight performance cost, the cost of creating a list of 52 integers is tiny and the Fisher-Yates Shuffle is efficient. The benefit of using the Fisher-Yates Shuffle is that every permutation is equally likely. I added two wild cards, 2 and 8. If both wild cards are drawn eight beats two, makes the determine result logic a little simpler. 

### Testing
I added unit tests for the Deck class. I feel that I maybe could of made the logic in Game a bit more unit testable and added some tests there, perhaps to check the scoreboard was generated correctly. I added a unit test for the shuffle method, even though it's possible that the deck could be shuffled in the exact order it was created. The likelhood of this happening is tiny and I wanted to assert that the shuffle method was working.

## Source Control
I used git to document how the project developed.

## Docker
I've also added a docker file so the project can be published and ran anywhere!

In the root of the HighCard project run:
``` shell
$ docker build . -t high-card
$ docker run high-card
```

