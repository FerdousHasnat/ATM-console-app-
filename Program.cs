// See https://aka.ms/new-console-template for more information
using System;
public class cardHolder 
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }   

    public String getNum() 
    { 
        return cardNum;
    }

    public int getPin() 
    {
        return pin;
    }
    public String getFirstName() 
    {
        return firstName;
    }

    public String getLastName() 
    {
        return lastName;
    }

    public double getBalance() 
    {
        return balance; 
    }

    public void setNum(String newCardNum) 
    {
        cardNum = newCardNum; 
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName) 
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName) 
    { 
        lastName = newLastName;
    }

    public void setBalance( double newBalance) 
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOption()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit( cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double deposit = Double. Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currnetUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawl = Double.Parse(Console.ReadLine());

            //check if the user has enough money
            if(currnetUser.getBalance() > withdrawl) 
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currnetUser.setBalance(currnetUser.getBalance() - withdrawl);
                Console.WriteLine("You're good to go!");
            }
            

        }

        void balance (cardHolder currentUser)
        {
            Console.WriteLine("Current Balacne: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders= new List<cardHolder>();
        cardHolders.Add(new cardHolder("123454321", 1234, "john","Griffith",150.31));
        cardHolders.Add(new cardHolder("345234456", 1234, "Tom", "harley", 250.31));
        cardHolders.Add(new cardHolder("876567456", 7657, "Tabes", "papa", 350.31));
        cardHolders.Add(new cardHolder("198789689", 9879, "Ashley", "young", 450.31));
        cardHolders.Add(new cardHolder("134573456", 0758, "Fryeya", "Smith", 550.31));

        //promt user
        Console.Out.WriteLine("Welcome to SimpleATM");
        Console.Out.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // check against our data
                currentUser = cardHolders.FirstOrDefault(args => args.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine(" card not recogniezed. Please try again"); }
            }
            catch { Console.WriteLine("card not recogniezed. Please try again"); }
        }
        Console.Out.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                             
                if (currentUser.getPin()==userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.Out.WriteLine("Welcome "+ currentUser.getFirstName()+ " :D");
        int option = 0;
        do
        {
            printOption();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option ==1) { deposit(currentUser); }
            else if (option==2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.Out.WriteLine("Thank you ! Have a nice day :)");
    }
}
