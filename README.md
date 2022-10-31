# Test Driven Development

This is the idicative solution to the exercise in the test first principle used in XP. 
Note that this is "just" the final code and not a thorough description on how to work. 
However, if you followed the workflow described in the exercise description and below, you should have worked "test first".

## Test First Workflow 

1. Code the test to validate only the specific requirements.  
2. erify that you can’t compile (because the code you want to test doesn’t exist yet).  
3. Implement just enough code (a stub/empty class) to make the code compile.  
4. Verify that your test fails   
5. Only implement just enough code to make the test pass.  

## Solution
Your task was to implement a *model layer* in the application using the user stories below, and using the test first coding technique to ensure simple design according to the acceptance tests.
Of course, the stories cover a lot more functionality than just that in the model layer, but thats not quite the point of test first.
When writing the test, you define the minimum viable classes and functions to sustain the user story in all aspects of the solution, that is the model layer, the business logic layer, and the user interface layer.
In this exercise it is only the model layer you should work on.

---
 
## Story 1  
To be able to sell books the administrator of the web shop must be able to create and select books from the system.

### User Story  
> As an administrator, I want to be able to add new books to the store, So there’s stock for customers to purchase from.

### Success criteria: 
* That a book is added to the store.
* That a book only is added if it is in a valid state (i.e., non-negative price, title/author/ISBN is a string longer than one character, etc.)

### Suggested tests
As suggested above we wil be working with a couple of concepts here:
* Two different roles: *Administrator* and *Customer*. Roles are, however, not important in the model layer (unless they represent data significant to the function of the program) so we leave them out at first.
* The *Book* object is important, since the story will not exist without it.
* It can be discussed whether it is a good idea to create the store as an object, but in this case we need something to represent our inventory, and the *book store* is perfect for that.  

This leaves us with to classes: **BookStore** and **Book**, and the tests should confirm that it is possible to add valid books to the store.  

When the tests are written, your implement the code in the model layer that makes it compile but not pass. Then add code so the tests passes.

---
 
## Story 2  
The second story is a clean-up story. 
It is probably not a good idea to delete books we already have sold because the tax authorities might want to see our previous sales. 
Create the delete functionality on the collection, so it receives the ISBN number of the book as the identification of what book to delete (mark it deleted somehow, without removing the book object).

### User Story  
> As an administrator, I want to be able to mark a book as deleted, so we no longer sell it, but it still exists in our records.

### Success Criteria  
* That the book is marked as deleted, but not removed (soft deleted)
* If an already deleted book is deleted again nothing happens and it stays deleted
* If a non-existing book is deleted, no exceptions occur

### Suggested Tests  
This user story gives us a little more information on the properties and behavior of a Book object.
First of all, we need a way to mark a book as deleted, without deleting it completely from the collection. 
This can be done by adding a property that can be true or false, indicating whether the object is available or not.
This is, however, internal behavior in the Book class, so the test should not be aware of this.

The tests calls a *Delete* method on the BookStore object and asserts the result, according to the success criteria. 

After the test is written, you add code in the BookStore class so it can compile, but not pass. After that add code so the tests passes

---
 
## Story 3  
After the manager has populated the web shop with some books the user needs to be able to find them.

### User Story  
> As a user, I want to be able to search for books using a single input (part of author or title), so that I can find the books I want.

### Success Criteria
* A search for a partial title, should find matching books
* A search for a partial authorname, should find matching books
* A search for a word that is part of title of one book and authorname of another, should find both books
* Search for a word that is in neither part of a title or authername, does not find any books

### Suggested Tests

---
 
## Story 4  
The next step is then for the user to place the found books into a shopping cart of some sort. 

### User Story  
> As a user, I want to be able to put books into a shopping cart, so that I can buy them.

### Success Criteria
* That a book can be added

### Suggested Tests 

---
 
## Story 5  
After the creation of the shopping cart the next natural step is allowing the user to change quantity of the books in the cart.

### User Story  
> As a user, I want to be able to adjust the quantity of an item in the cart, so that I’m buying the correct amount of each book. If I set the quantity to zero, I want the item removed from the cart entirely.

### Success Criteria 
* When a bool is added or removed, the subtotal for that book is calculated correctly
* When a book is added or removed, the total price for the order is calculated correctly
* When the quantity of a book is changed to zero, the book is removed and the total price for the order is calculated correctly

### Suggested Tests 

