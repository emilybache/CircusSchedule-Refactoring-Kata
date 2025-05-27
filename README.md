Circus Schedule Refactoring Kata
================================

The idea of this exercise is to practice refactoring skills. You need to introduce an anti-corruption layer of domain objects that enable you to work with the domain for scheduling a Circus show without being restricted by the legacy design choices. Use the 'adapter' pattern. There are some tests with realistic test data to help you.

The classes in the "Legacy" module are difficult to change but give you access to the underlying data for a Circus show schedule. The interfaces in "ForFrontEnd" are used by the front end to display the show schedule. You can't easily change those either. The part in between is what you are free to refactor.

The Domain model
----------------

(Note this exercise is not finished and not all these classes exist yet)

A CircusShow can be thought of as a tree of domain objects. A show has several other Shows or Show Parts which contain Acts. Each Act needs one or more Artists to perform in it. Each Artist has several Skills. The link from Acts to Artists goes via Assignments which are skill-specific. (You can't assign a Clown to a Trapeze Act!).


Acknowledgements
----------------

This exercise was created by Emily Bache

