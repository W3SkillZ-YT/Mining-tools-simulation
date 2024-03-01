using System;
using System.Globalization;
using System.IO;

class Program
{
    static void WatchWallet()
    {
        Console.WriteLine("Watch Wallet Options:");
        Console.WriteLine("1. Manage Wallet");
        Console.WriteLine("2. Create Wallet");
        Console.Write("Enter your choice (1-2): ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
        {
            Console.WriteLine("Invalid input. Please enter 1 or 2.");
            Console.Write("Enter your choice (1-2): ");
        }

        switch (choice)
        {
            case 1:
                ManageWallet();
                break;
            case 2:
                CreateWallet();
                break;
        }
    }

    static void ManageWallet()
    {
        Console.Write("Enter the path to your wallet (.cw file): ");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Wallet file not found.");
            return;
        }

        Console.WriteLine("\nManage Wallet Options:");
        Console.WriteLine("1. Change Wallet Value");
        Console.WriteLine("2. Change Wallet Type");
        Console.Write("Enter your choice (1-2): ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
        {
            Console.WriteLine("Invalid input. Please enter 1 or 2.");
            Console.Write("Enter your choice (1-2): ");
        }

        switch (choice)
        {
            case 1:
                ChangeWalletValue(filePath);
                break;
            case 2:
                ChangeWalletType(filePath);
                break;
        }
    }

    static void ChangeWalletValue(string filePath)
    {
        Console.Write("Do you want to create a new wallet record? (yes/no): ");
        string createNewRecord = Console.ReadLine().ToLower();

        if (createNewRecord != "yes")
        {
            Console.WriteLine("No new record created.");
            return;
        }

        Console.Write("Enter the amount (€): ");
        double amount;
        while (!double.TryParse(Console.ReadLine().Replace(".", ","), out amount) || amount < 0)
        {
            Console.WriteLine("Invalid input. Please enter a non-negative number.");
            Console.Write("Enter the amount (€): ");
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Record\n{amount:F2}");
            }
            Console.WriteLine("New wallet record created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }






    static void ChangeWalletType(string filePath)
    {
        Console.WriteLine("Choose the new wallet type:");
        Console.WriteLine("1. Hardware Wallet");
        Console.WriteLine("2. Software Wallet");
        Console.Write("Enter your choice (1-2): ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
        {
            Console.WriteLine("Invalid input. Please enter 1 or 2.");
            Console.Write("Enter your choice (1-2): ");
        }

        string newType = (choice == 1) ? "Hardware Wallet" : "Software Wallet";
        File.WriteAllText(filePath, newType);
        Console.WriteLine($"Wallet type updated: {newType}");
    }

    static void CreateWallet()
    {
        Console.Write("Enter the name for your new wallet: ");
        string walletName = Console.ReadLine();

        Console.WriteLine("Choose the wallet type:");
        Console.WriteLine("1. Hardware Wallet");
        Console.WriteLine("2. Software Wallet");
        Console.Write("Enter your choice (1-2): ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
        {
            Console.WriteLine("Invalid input. Please enter 1 or 2.");
            Console.Write("Enter your choice (1-2): ");
        }

        string walletType = (choice == 1) ? "Hardware Wallet" : "Software Wallet";

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, $"{walletName}.cw");
        File.WriteAllText(filePath, walletType);

        Console.WriteLine($"Wallet \"{walletName}\" created as a {walletType} and saved to desktop.");
    }


    static void CrackWallets()
    {
        string[] walletTypes = { "Hardware Wallets", "Software Wallets" };

        Console.WriteLine("Available Wallet Types to Crack:");
        for (int i = 0; i < walletTypes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {walletTypes[i]}");
        }

        Console.Write("Enter your choice (1-2): ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 2.");
            Console.Write("Enter your choice (1-2): ");
        }

        Console.Write("Enter how many attempts you want to make (1-10): ");
        int attempts;
        while (!int.TryParse(Console.ReadLine(), out attempts) || attempts < 1 || attempts > 10)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
            Console.Write("Enter how many attempts you want to make (1-10): ");
        }

        Random random = new Random();
        int successfulCracks = 0;
        double totalAmount = 0;

        for (int i = 0; i < attempts; i++)
        {
            bool success = random.NextDouble() < 0.5; // 50% success rate
            if (success)
            {
                successfulCracks++;
                totalAmount += random.NextDouble() * 1000; // Random amount in wallet (up to 1000)
            }
        }

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath;

        Console.Write("Do you already have a log file? (yes/no): ");
        string response = Console.ReadLine().ToLower();
        if (response == "yes")
        {
            Console.Write("Enter the full path to your log file: ");
            filePath = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("A new log file will be created on your desktop.");
            filePath = Path.Combine(desktopPath, "cracked_wallets.txt");
        }

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine($"Wallet Type: {walletTypes[choice - 1]}");
            writer.WriteLine($"Number of Attempts: {attempts}");
            writer.WriteLine($"Number of Successful Cracks: {successfulCracks}");
            writer.WriteLine($"Total Amount Cracked: {totalAmount:F2}");
            writer.WriteLine(); // Empty line for separation
        }

        Console.WriteLine($"Cracking results saved to {filePath}");
    }


    static void MineCryptoCurrency()
    {
        string[] cryptoCurrencies = {
            "Bitcoin (BTC)", "Ethereum (ETH)", "Binance Coin (BNB)", "Solana (SOL)", "Cardano (ADA)",
            "Tether (USDT)", "Ripple (XRP)", "Polkadot (DOT)", "Dogecoin (DOGE)", "Chainlink (LINK)",
            "Litecoin (LTC)", "Bitcoin Cash (BCH)", "Stellar (XLM)", "Uniswap (UNI)", "Terra (LUNA)",
            "Avalanche (AVAX)", "Polygon (MATIC)", "VeChain (VET)", "Filecoin (FIL)", "Tron (TRX)"
        };

        int choice;
        int mineCount;
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath;

        Console.WriteLine("\nAvailable Crypto Currencies to Mine:");
        for (int i = 0; i < cryptoCurrencies.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {cryptoCurrencies[i]}");
        }

        Console.Write("Enter your choice (1-20): ");
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 20)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 20.");
            Console.Write("Enter your choice (1-20): ");
        }

        Console.Write("Enter how many times you want to mine (1-35): ");
        while (!int.TryParse(Console.ReadLine(), out mineCount) || mineCount < 1 || mineCount > 35)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 35.");
            Console.Write("Enter how many times you want to mine (1-35): ");
        }

        Random random = new Random();
        double successRate = random.NextDouble();
        double miningReward = 0;

        if (successRate < 0.7) // 70% success rate
        {
            miningReward = random.NextDouble() * 100; // Random reward amount
            Console.WriteLine($"Mining successful! You earned {miningReward:F2} units of {cryptoCurrencies[choice - 1]}.");
        }
        else
        {
            Console.WriteLine("Mining failed. No reward obtained.");
        }

        Console.Write("Do you already have a log file? (yes/no): ");
        string response = Console.ReadLine().ToLower();
        if (response == "yes")
        {
            Console.Write("Enter the full path to your log file: ");
            filePath = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("A new log file will be created on your desktop.");
            filePath = Path.Combine(desktopPath, "mined_crypto.txt");
        }

        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine($"Crypto Currency: {cryptoCurrencies[choice - 1]}");
                writer.WriteLine($"Mining Reward: {miningReward:F2}");
                writer.WriteLine($"Number of Attempts: {mineCount}");
            }
            Console.WriteLine($"Mining results saved to {filePath}");
        }
        else
        {
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"Crypto Currency: {cryptoCurrencies[choice - 1]}");
                writer.WriteLine($"Mining Reward: {miningReward:F2}");
                writer.WriteLine($"Number of Attempts: {mineCount}");
            }
            Console.WriteLine($"Mining results appended to existing file: {filePath}");
        }
    }



    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("\nCrypto Mining Tools (Simulation)");
            Console.WriteLine("1. Watch Wallet");
            Console.WriteLine("2. Crack Wallets");
            Console.WriteLine("3. Mine Crypto Currency");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    WatchWallet();
                    break;
                case 2:
                    CrackWallets();
                    break;
                case 3:
                    MineCryptoCurrency();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        } while (choice != 4);
    }
}
