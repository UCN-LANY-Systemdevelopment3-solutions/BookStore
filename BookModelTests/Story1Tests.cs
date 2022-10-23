

using BookShop.Model;

namespace BookModelTests
{
    public class Story1Tests
    {
        // 1. Code the test to validate only the specific requirements.
        // 2. Verify that you can’t compile (because the code you want to test doesn’t exist yet).
        // 3. Implement just enough code (a stub/empty class) to make the code compile.
        // 4. Verify that your test fails
        // 5. Only implement just enough code to make the test pass.

        [Fact]
        public void AddValidBooksToStore()
        {
            // Arrange
            BookStore store = new();
            Book book1 = new("978-1-4842-7868-0", "Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming", "Andrew Troelsen", 299.00, 10);
            Book book2 = new("978-1-59327-826-7", "Serious Cryptography", "Jean-Philippe Aumasson", 349.00, 8);
            Book book3 = new("978-1-4842-3639-0", "Design Patterns in C#", "Vaskaran Sarcar", 199.00, 12);

            // Act
            store.Add(book1);
            store.Add(book2);
            store.Add(book3);

            // Assert
            Assert.Equal(3, store.Titles.Count());
        }
    }
}