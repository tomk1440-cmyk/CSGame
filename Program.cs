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
    penize = 1000;
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
int choice = Convert.ToInt32(Console.ReadLine());
if (choice == 1)
{
    Console.WriteLine("Your stats:");
    Console.WriteLine("Money: " + penize);
    Console.WriteLine("Heals: " + heals);
    Console.WriteLine("What do you  want to do?") ;
    Console.WriteLine("1. Play against AI");
    Console.WriteLine("2. Exit to main menu");
    int selection2 = Convert.ToInt32(Console.ReadLine());
    if (selection2 == 1) {
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
        Console.WriteLine("Are you ready?\nPress any key...");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Welcome to the arena!");
        Random rnd = new Random();
        int opphealth = rnd.Next(100, 151);
        int health = 100;
        battle:
        int strength = rnd.Next(1, 15);
        int oppstrength = rnd.Next(1, 15);
        Console.WriteLine("You have " + health + " HP");
        Console.WriteLine("You have " + heals + " heals left");
        Console.WriteLine("Your attack strength is: " + strength);
        Console.WriteLine("Opponent HP: " + opphealth);
        Console.WriteLine("Do you want to 1. fight or 2. heal?");
        int sel3 = Convert.ToInt32(Console.ReadLine());
        if (sel3 == 1)
        {
            Console.Clear();
            Console.WriteLine("HP of your opponent: " + opphealth);
            Console.WriteLine("Strength of your opponent: " + oppstrength);
            await Task.Delay(1200);
            opphealth = opphealth - strength;
            if (opphealth <= 0) {
                Console.WriteLine("Congratulations, YOU WON!");
                Console.WriteLine("Press any key to go into the menu");
                Console.Read();
                goto mainmenu;
            } 
            Console.WriteLine("Opponent recieved damage, he now has:" + opphealth + " hp left.");
            await Task.Delay(1200);
            Console.WriteLine("Opponent fighted back, he dealt you " + oppstrength + "damage.");
            await Task.Delay(1200);
            health = health - oppstrength;
            Console.WriteLine("Your new health is: " + health);
            await Task.Delay(1200);
            if (health == 0) {
                Console.WriteLine("You died. Better luck next time!");
            }

            else if (health > 0)
            {
                Console.Clear();
                goto battle;
            }

        }
        else if (sel3 == 2) {
            healing:
            Console.WriteLine("How much do you want to heal?");
            Console.WriteLine("Heals left:" + heals);
            int healing1 = Convert.ToInt32(Console.ReadLine());
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

            if (healing1 > heals) {
                Console.WriteLine("You typed more heals than you have!\nGoing back to healing menu!");
                await Task.Delay(300);
                goto healing;
            }


        }




    }
    else if (selection2 == 2)
    {
        Console.WriteLine("Going to main menu...");
        await Task.Delay(3000);
        Console.Clear();
        goto mainmenu;
    }
}
else if (choice == 2)
{
    Console.Clear();
    Console.WriteLine("You chose: 2");
    await Task.Delay(3000);
    Console.Clear();
    Console.WriteLine(" __        __   _                               _             _   _                   _                 _ \n \\ \\      / /__| | ___ ___  _ __ ___   ___     | |_ ___      | |_| |__   ___      ___| |__   ___  _ __ | |\n  \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\    | __/ _ \\     | __| '_ \\ / _ \\    / __| '_ \\ / _ \\| '_ \\| |\n   \\ V  V /  __/ | (_| (_) | | | | | |  __/    | || (_) |    | |_| | | |  __/    \\__ \\ | | | (_) | |_) |_|\n    \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|     \\__\\___/      \\__|_| |_|\\___|    |___/_| |_|\\___/| .__/(_)\n                                                                                                 |_|      ");
    Console.WriteLine("Your current balance is: " + penize);
    Console.WriteLine("                                                                                                                                        \n,--.   ,--.,--.               ,--.        ,--.                                                                 ,--.       ,--.          \n|  |   |  ||  ,---.  ,--,--.,-'  '-.    ,-|  | ,---.    ,--. ,--.,---. ,--.,--.   ,--.   ,--. ,--,--.,--,--, ,-'  '-.   ,-'  '-. ,---.  \n|  |.'.|  ||  .-.  |' ,-.  |'-.  .-'   ' .-. || .-. |    \\  '  /| .-. ||  ||  |   |  |.'.|  |' ,-.  ||      \\'-.  .-'   '-.  .-'| .-. | \n|   ,'.   ||  | |  |\\ '-'  |  |  |     \\ `-' |' '-' '     \\   ' ' '-' ''  ''  '   |   .'.   |\\ '-'  ||  ||  |  |  |       |  |  ' '-' ' \n'--'   '--'`--' `--' `--`--'  `--'      `---'  `---'    .-'  /   `---'  `----'    '--'   '--' `--`--'`--''--'  `--'       `--'   `---'  \n                         ,------.                       `---'                                                                           \n,--.                    '  .--.  '                                                                                                      \n|  |-. ,--.,--.,--. ,--.'--' _|  |                                                                                                      \n| .-. '|  ||  | \\  '  /  .--' __'                                                                                                       \n| `-' |'  ''  '  \\   '   `---'                                                                                                          \n `---'  `----' .-'  /    .---.                                                                                                          \n               `---'     '---'                                                                                                          ");
    Console.WriteLine("1. Apple - gives you ability to restore 50HP, item is stackable with others too \n2. Beer - gives you ability to restore 100HP, stackable with 1.");
    Console.WriteLine("Apple costs: 50 Gold\nBeer costs: 100 Gold");
    Console.WriteLine("1.\n   ,--./,-.\n / #      \\\n|          |\n \\        /    hjw\n  `._,._,'\n");
    Console.WriteLine("2.\n .~~~~.\ni====i_\n|cccc|_)\n|cccc|   hjw\n`-==-'\n");
    Console.WriteLine("So, what do you want?");
    int selection1 = Convert.ToInt32(Console.ReadLine());
    if (selection1 == 1)
    {
        penize = penize - 50;
        heals = heals + 50;
        File.WriteAllText(soubor, penize.ToString());
        File.WriteAllText(soubor2, heals.ToString());
        Console.WriteLine("You bought an Apple, your balance is: " + penize + " your heals balance is: " + heals);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        goto mainmenu;
        
    }
    else if (selection1 == 2)
    {
        penize = penize - 100;
        heals = heals + 100;
        File.WriteAllText(soubor, penize.ToString());
        File.WriteAllText(soubor2, heals.ToString());
        Console.WriteLine("You bought a Beer, your balance is: " + penize + " your heals balance is: " + heals);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        goto mainmenu;
    }
}
else if (choice == 3)
{
    Console.Clear();
    Console.WriteLine("You chose: 3");
    await Task.Delay(3000);
    Console.WriteLine("Exiting.....");
    await Task.Delay(3000);
}