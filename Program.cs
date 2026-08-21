using System.Numerics;
using System.Security;

string soubor = "penize.txt";
string soubor2 = "heals.txt";
int penize;

if (File.Exists(soubor))
{
    string obsah = File.ReadAllText(soubor);
    if (!int.TryParse(obsah, out penize)) penize = 1000;
}
else
{
    penize = 100;
    File.WriteAllText(soubor, penize.ToString());
}
int heals;
if (File.Exists(soubor2))
{
    string obsah = File.ReadAllText(soubor2);
    if (!int.TryParse(obsah, out heals)) heals = 0;
}
else
{
    heals = 0;
    File.WriteAllText(soubor2, heals.ToString());
}
Console.WriteLine(" __        __   _                                __                _                         _ \n \\ \\      / /__| | ___ ___  _ __ ___   ___      / _| ___  _ __ ___(_) __ _ _ __   ___ _ __  | |\n  \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\    | |_ / _ \\| '__/ _ \\ |/ _` | '_ \\ / _ \\ '__| | |\n   \\ V  V /  __/ | (_| (_) | | | | | |  __/    |  _| (_) | | |  __/ | (_| | | | |  __/ |    |_|\n    \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|    |_|  \\___/|_|  \\___|_|\\__, |_| |_|\\___|_|    (_)\n                                                                     |___/                     ");
mainmenu:
Console.WriteLine("Main Menu");
Console.WriteLine("\n What do you want to do?");
Console.WriteLine("1. Play the game  2. Visit the shop  3. Exit");
var choice = Console.ReadLine();
if (choice == "1")
{
    Game:
    Console.WriteLine("Your stats:");
    Console.WriteLine("Money: " + penize);
    Console.WriteLine("Heals: " + heals);
    Console.WriteLine("What do you  want to do?");
    Console.WriteLine("1. Play against AI");
    Console.WriteLine("2. Exit to main menu");
    var selection2 = Console.ReadLine();
    if (selection2 == "1")
    {
        jardagame:
        Console.Clear();
        Console.WriteLine("Launching game...");
        await Task.Delay(3000);
        Console.Clear();
        Console.WriteLine("Welcome to the battle field");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("This is you:");
        Console.WriteLine(" O\n/|\\\n /\\");
        Console.WriteLine("Are you ready?\nPress 1 for easy mode and 2 for hard mode");
        var difficulty = Console.ReadLine();
        Random rnd = new Random();

        if (difficulty == "1")
        {
            arena:
            Console.Clear();
            Console.WriteLine("Welcome to the arena!");
            
            int opphealth = rnd.Next(100, 151);
            int health = 100;
            int strength = rnd.Next(1, 15);
            int oppstrength = rnd.Next(1, 15);
            battle:
            Console.WriteLine("You have " + health + " HP");
            Console.WriteLine("You have " + heals + " heals left");
            Console.WriteLine("Your attack strength is: " + strength);
            Console.WriteLine("Opponent HP: " + opphealth);
            Console.WriteLine("Do you want to 1. fight or 2. heal?");
            var sel3 = Console.ReadLine();
            if (sel3 == "1")
            {
                Console.Clear();
                Console.WriteLine("HP of your opponent: " + opphealth);
                Console.WriteLine("Strength of your opponent: " + oppstrength);
                await Task.Delay(1200);
                opphealth = opphealth - strength;
                if (opphealth <= 0)
                {
                    Console.WriteLine("Congratulations, YOU WON!");
                    Console.WriteLine("Your award is 500!");
                    penize = penize + 500;
                    File.WriteAllText(soubor, penize.ToString());
                    Console.WriteLine("Press any key to go into the menu");
                    Console.ReadKey();
                    Console.Clear();
                    goto mainmenu;
                }
                Console.WriteLine("Opponent recieved damage, he now has:" + opphealth + " hp left.");
                await Task.Delay(1200);
                Console.WriteLine("Opponent fighted back, he dealt you " + oppstrength + "damage.");
                await Task.Delay(1200);
                health = health - oppstrength;
                Console.WriteLine("Your new health is: " + health);
                await Task.Delay(1200);
                if (health <= 0)
                {
                    Console.WriteLine("You died. Better luck next time!");
                    Console.WriteLine("Press any key to go into the menu");
                    Console.ReadKey();
                    Console.Clear();
                    goto mainmenu;
                }
                else if (health > 0)
                {
                    Console.Clear();
                    goto battle;
                }
            }
            else if (sel3 == "2")
            {
            healing:
                Console.WriteLine("How much do you want to heal?");
                Console.WriteLine("Heals left:" + heals);
                var healing1 = Convert.ToInt32(Console.ReadLine());
                if (healing1 <= heals)
                {
                    await Task.Delay(300);
                    Console.WriteLine("Healing in progress.");
                    await Task.Delay(300);
                    Console.WriteLine("Healing in progress.");
                    await Task.Delay(300);
                    Console.WriteLine("Healing in progress.");
                    health = health + healing1;
                    heals = heals - healing1;
                    Console.WriteLine("New health:" + health);
                    Console.WriteLine("You have " + heals + " heals left");
                    File.WriteAllText(soubor2, heals.ToString());
                    Console.WriteLine("Going back.");
                    await Task.Delay(300);
                    Console.WriteLine("Going back..");
                    await Task.Delay(300);
                    Console.WriteLine("Going back...");
                    await Task.Delay(300);
                    goto battle;
                }
                if (healing1 > heals)
                {
                    Console.WriteLine("You typed more heals than you have!\nGoing back to healing menu!");
                    await Task.Delay(300);
                    goto healing;
                }
                else {
                    Console.WriteLine("Invalid input.\nGoing back");
                }


            }
            else {
                goto battle;
            }
        }
        else if (difficulty == "2")
        {
            Console.Clear();
            Console.WriteLine("Welcome to the arena!");
            int opphealth2 = rnd.Next(100, 251);
            int health2 = 100;
            battlehard:
            int strength2 = rnd.Next(1, 15);
            int oppstrength2 = rnd.Next(1, 25);
            Console.WriteLine("You have " + health2 + " HP");
            Console.WriteLine("You have " + heals + " heals left");
            Console.WriteLine("Your attack strength is: " + strength2);
            Console.WriteLine("Opponent HP: " + opphealth2);
            Console.WriteLine("Do you want to 1. fight or 2. heal?");
            var sel4 = Console.ReadLine();
            if (sel4 == "1")
            {
                Console.Clear();
                Console.WriteLine("HP of your opponent: " + opphealth2);
                Console.WriteLine("Strength of your opponent: " + oppstrength2);
                await Task.Delay(1200);
                opphealth2 = opphealth2 - strength2;
                if (opphealth2 <= 0)
                {
                    Console.WriteLine("Congratulations, YOU WON!");
                    Console.WriteLine("Your award is 1000!");
                    penize = penize + 1000;
                    File.WriteAllText(soubor, penize.ToString());
                    Console.WriteLine("Press any key to go into the menu");
                    Console.ReadKey();
                    Console.Clear();
                    goto mainmenu;
                }
                Console.WriteLine("Opponent recieved damage, he now has:" + opphealth2 + " hp left.");
                await Task.Delay(1200);
                Console.WriteLine("Opponent fighted back, he dealt you " + oppstrength2 + "damage.");
                await Task.Delay(1200);
                health2 = health2 - oppstrength2;
                Console.WriteLine("Your new health is: " + health2);
                await Task.Delay(1200);
                if (health2 <= 0)
                {
                    Console.WriteLine("You died. Better luck next time!");
                    Console.WriteLine("Press any key to go into the menu");
                    Console.ReadKey();
                    Console.Clear();
                    goto mainmenu;
                }
                else if (health2 > 0)
                {
                    Console.Clear();
                    goto battlehard;
                }
            }
            else if (sel4 == "2")
            {
            healing2:
                Console.WriteLine("How much do you want to heal?");
                Console.WriteLine("Heals left:" + heals);
                int healing2 = Convert.ToInt32(Console.ReadLine());
                if (healing2 <= heals)
                {
                    await Task.Delay(300);
                    Console.WriteLine("Healing in progress.");
                    await Task.Delay(300);
                    Console.WriteLine("Healing in progress.");
                    await Task.Delay(300);
                    Console.WriteLine("Healing in progress.");
                    health2 = health2 + healing2;
                    heals = heals - healing2;
                    Console.WriteLine("New health:" + health2);
                    Console.WriteLine("You have " + heals + " heals left");
                    File.WriteAllText(soubor2, heals.ToString());
                    Console.WriteLine("Going back.");
                    await Task.Delay(300);
                    Console.WriteLine("Going back..");
                    await Task.Delay(300);
                    Console.WriteLine("Going back...");
                    await Task.Delay(300);
                    goto battlehard;
                }
                if (healing2 > heals)
                {
                    Console.WriteLine("You typed more heals than you have!\nGoing back to healing menu!");
                    await Task.Delay(300);
                    goto healing2;
                }
            }
            else {
                goto battlehard;
            }
        }
        else
        {
            goto jardagame;
        }
    }
    else if (selection2 == "2")
    {
        Console.WriteLine("Going to main menu...");
        await Task.Delay(3000);
        Console.Clear();
        goto mainmenu;
    }
    else {
        goto Game;
    }
}
else if (choice == "2")
{
    Console.Clear();
    Console.WriteLine("You chose: 2");
    await Task.Delay(3000);
    Console.Clear();
    shop:
    Console.WriteLine(" __        __   _                               _             _   _                   _                 _ \n \\ \\      / /__| | ___ ___  _ __ ___   ___     | |_ ___      | |_| |__   ___      ___| |__   ___  _ __ | |\n  \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\    | __/ _ \\     | __| '_ \\ / _ \\    / __| '_ \\ / _ \\| '_ \\| |\n   \\ V  V /  __/ | (_| (_) | | | | | |  __/    | || (_) |    | |_| | | |  __/    \\__ \\ | | | (_) | |_) |_|\n    \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|     \\__\\___/      \\__|_| |_|\\___|    |___/_| |_|\\___/| .__/(_)\n                                                                                                 |_|      ");
    Console.WriteLine("Your current balance is: " + penize);
    Console.WriteLine("                                                                                                                                        \n,--.   ,--.,--.               ,--.        ,--.                                                                 ,--.       ,--.          \n|  |   |  ||  ,---.  ,--,--.,-'  '-.    ,-|  | ,---.    ,--. ,--.,---. ,--.,--.   ,--.   ,--. ,--,--.,--,--, ,-'  '-.   ,-'  '-. ,---.  \n|  |.'.|  ||  .-.  |' ,-.  |'-.  .-'   ' .-. || .-. |    \\  '  /| .-. ||  ||  |   |  |.'.|  |' ,-.  ||      \\'-.  .-'   '-.  .-'| .-. | \n|   ,'.   ||  | |  |\\ '-'  |  |  |     \\ `-' |' '-' '     \\   ' ' '-' ''  ''  '   |   .'.   |\\ '-'  ||  ||  |  |  |       |  |  ' '-' ' \n'--'   '--'`--' `--' `--`--'  `--'      `---'  `---'    .-'  /   `---'  `----'    '--'   '--' `--`--'`--''--'  `--'       `--'   `---'  \n                         ,------.                       `---'                                                                           \n,--.                    '  .--.  '                                                                                                      \n|  |-. ,--.,--.,--. ,--.'--' _|  |                                                                                                      \n| .-. '|  ||  | \\  '  /  .--' __'                                                                                                       \n| `-' |'  ''  '  \\   '   `---'                                                                                                          \n `---'  `----' .-'  /    .---.                                                                                                          \n               `---'     '---'                                                                                                          ");
    Console.WriteLine("1. Apple - gives you ability to restore 50HP, item is stackable with others too \n2. Beer - gives you ability to restore 100HP, stackable with 1.");
    Console.WriteLine("Apple costs: 50 Gold\nBeer costs: 100 Gold");
    Console.WriteLine("1.\n   ,--./,-.\n / #      \\\n|          |\n \\        /    hjw\n  `._,._,'\n");
    Console.WriteLine("2.\n .~~~~.\ni====i_\n|cccc|_)\n|cccc|   hjw\n`-==-'\n");
    Console.WriteLine("So, what do you want?");
    var selection1 = Console.ReadLine();
    if (selection1 == "1")
    {
        if (penize >= 50)
        {
            penize = penize - 50;
            heals = heals + 50;
            File.WriteAllText(soubor, penize.ToString());
            File.WriteAllText(soubor2, heals.ToString());
            Console.WriteLine("You bought an Apple, your balance is: " + penize + " your heals balance is: " + heals);
        }
        else
        {
            Console.WriteLine("You don't have enough gold!");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        goto mainmenu;
    }
    else if (selection1 == "2")
    {
        if (penize >= 100)
        {
            penize = penize - 100;
            heals = heals + 100;
            File.WriteAllText(soubor, penize.ToString());
            File.WriteAllText(soubor2, heals.ToString());
            Console.WriteLine("You bought a Beer, your balance is: " + penize + " your heals balance is: " + heals);
        }
        else
        {
            Console.WriteLine("You don't have enough gold!");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        goto mainmenu;
    }
    else {
        Console.WriteLine("Invalid input....");
        Console.WriteLine("Going to shop");
        goto shop;
    }
}
else if (choice == "3")
{
    Console.Clear();
    Console.WriteLine("You chose: 3");
    await Task.Delay(3000);
    Console.WriteLine("Exiting.....");
    await Task.Delay(3000);
}
else {
    Console.WriteLine("Invalid input....");
    Console.WriteLine("Going to main menu");
    await Task.Delay(3000);
    Console.Clear();
    goto mainmenu;
}
