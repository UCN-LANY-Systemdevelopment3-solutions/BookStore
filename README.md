# Test Driven Development

To try out Test Driven Development (TDD) we will develop the model layer for a web shop selling books. 

The web shop will be created using TDD or “test first” principle. You should be familiar with how to create unit tests in C# already. If not, see this link for information [Testing in Visual Studio](https://learn.microsoft.com/en-us/visualstudio/test/improve-code-quality?view=vs-2022). The link points to a main page and a lot of the information can be obtained through subpages so remember to read those as well.

## Working together  

Do the exercises in pairs to practice Pair Programming, and change roles (coder/supervisor) regularly (e. g. every 30 minutes). Compare your solutions within the group from time to time.

## Test Driven Development  

1. Code the test to validate only the specific requirements.  
2. erify that you can’t compile (because the code you want to test doesn’t exist yet).  
3. Implement just enough code (a stub/empty class) to make the code compile.  
4. Verify that your test fails   
5. Only implement just enough code to make the test pass.  

## Make Good Code
“*Make the simplest code possible to make a test pass*” doesn’t mean: “*forget everything you know about writing good code*”!  
Write good, [clean code](https://dzone.com/articles/clean-code-summary-and-key-points). Write code that expresses your intent through naming and structure. 
Essentially: give meaningful names to classes, methods, variables and arguments, so people understand what’s going on. Use the phase where you’re writing the test, to plan how you would like to be able to use the actual code that you will write later. 

Implement the following stories using the test first coding technique to ensure simple design according to the acceptance tests. The model classes must be added to the Model project.

---
 
## Story 1  
To be able to sell books the administrator of the web shop must be able to create and select books from the system.

### User Story  
> As an administrator, I want to be able to add new books to the store, So there’s stock for customers to purchase from.

### Success criteria: 
* That a book is added to the store.
* That a book only is added if it is in a valid state (i.e., non-negative price, title/author/ISBN is a string longer than one character, etc.)

### Suggested tests
* Make a bookstore that contains at least three different books with the following attributes: ISBN (string), title(text), author (text), price (positive number), number on stock (zero, or positive)
* Add a book with invalid values (ISBN/Title/etc.) and make sure the store throws an ArgumentException

#### Note
Remember to encapsulate your data. Don’t make an inner List<Book> public. Instead create methods on the BookContainer for Adding, Removing and searching the inner collection as necessary.  

---
 
## Story 2  
The second story is a clean-up story. It is probably not a good idea to delete books we already have sold because the tax authorities might want to see our previous sales. Create the delete functionality on the collection, so it receives the ISBN number of the book as the identification of what book to delete (mark it deleted somehow, without removing the book object).

### User Story  
> As an administrator, I want to be able to mark a book as deleted, so we no longer sell it, but it still exists in our records.

### Success Criteria  
* That the book is marked as deleted, but not removed (soft deleted)
* If an already deleted book is deleted again nothing happens and it stays deleted
* If a non-existing book is deleted, no exceptions occur

### Suggested Tests  
* Delete a book and check it is still in the collection, and marked as deleted
* Delete a non existing book and check that no exeption is thrown
* Delete a book that is marked as deleted, and check that its state does not change

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
* Search a book by entering part of a title
* Search a book by entering part of the authors name
* Search a book by entering part of a title and part of the authors name
* Search a book by entering words that are not part of neither title nor name

---
 
## Story 4  
The next step is then for the user to place the found books into a shopping cart of some sort. 

### User Story  
> As a user, I want to be able to put books into a shopping cart, so that I can buy them.

### Success Criteria
* That a book can be added

### Suggested Tests 
* Put a book into the cart. Verify that the cart contains that title with the correct total on the cart
* Put another book into the cart. Verify that the cart contains that title with the new total on the cart

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
* Add a book to the cart. Verify the subtotal for that book and total for the cart
* Increase the quantity of a book. Verify that the subtotal and total goes up
* Decrease the quantity of a book. Verify that the subtotal and total goes down
* Remove a book by changing the quantity to zero. Verify that the book is removed, and the total has gone down

