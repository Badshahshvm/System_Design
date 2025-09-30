

public class Singleton {
    private static final Singleton instance = new Singleton();

    // private constructor
    private Singleton() {}

    public static Singleton getInstance() {
        return instance;
    }

    public void showMessage() {
        System.out.println("Hello from Singleton!");
    }
}

public class Main {
    public static void main(String[] args) {
      Singleton obj1 = Singleton.getInstance();
     Singleton obj2 = Singleton.getInstance();
        System.out.println(obj1 == obj2); // true (same instance)
    }
}


--------------------------------Second Way---------------------------------------------------------------------
  public class Singleton {
    private static Singleton instance;

    private Singleton() {}

    public staticSingleton getInstance() {
        if (instance == null) {
            instance = new Singleton(); // created only once
        }
        return instance;
    }
}

