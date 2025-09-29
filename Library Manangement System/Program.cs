// Book class
class Book {
    int id;
    String title;
    String author;
    boolean isAvailable;

    Book(int id, String title, String author) {
        this.id = id;
        this.title = title;
        this.author = author;
        this.isAvailable = true;
    }

    void borrow() {
        if (isAvailable) {
            isAvailable = false;
            System.out.println(title + " borrowed.");
        } else {
            System.out.println(title + " is not available.");
        }
    }

    void returnBook() {
        isAvailable = true;
        System.out.println(title + " returned.");
    }
}

// User class
class User {
    int id;
    String name;
    List<Book> borrowedBooks = new ArrayList<>();

    User(int id, String name) {
        this.id = id;
        this.name = name;
    }

    void borrowBook(Book book) {
        if (book.isAvailable) {
            book.borrow();
            borrowedBooks.add(book);
        } else {
            System.out.println("Book not available for borrowing.");
        }
    }

    void returnBook(Book book) {
        if (borrowedBooks.contains(book)) {
            book.returnBook();
            borrowedBooks.remove(book);
        }
    }
}

// Library class
class Library {
    List<Book> books = new ArrayList<>();
    List<User> users = new ArrayList<>();

    void addBook(Book book) {
        books.add(book);
    }

    void registerUser(User user) {
        users.add(user);
    }

    Book searchBook(String title) {
        for (Book b : books) {
            if (b.title.equalsIgnoreCase(title)) {
                return b;
            }
        }
        return null;
    }
}
