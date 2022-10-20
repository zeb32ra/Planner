using Planner;

Plan zametka1 = new Plan();

zametka1.date = DateTime.Now.ToShortDateString();
zametka1.DateTime = DateTime.Now.Date;
zametka1.name = "Feed the cat";
zametka1.description = " Feed Barsik.\n" +
    "Remeber that he is allergic to salmon!!!!";
zametka1.position = 1;


Plan zametka2 = new Plan();
zametka2.name = "Feed the turtle";
zametka2.description = "Food is in the fridge";
zametka2.date = DateTime.Now.ToShortDateString();
zametka2.DateTime = DateTime.Now.Date;
zametka2.position = 2;

Plan zametka3 = new Plan();
zametka3.name = "Go to MPT";
zametka3.description = "From 8:30 to 15:30";
zametka3.date = DateTime.Now.AddDays(1).ToShortDateString();
zametka3.DateTime = DateTime.Now.AddDays(1);
zametka3.position = 1;

Plan zametka4 = new Plan();
zametka4.name = "Do my homework";
zametka4.description = "Math, Informatics, Phylosophy";
zametka4.date = DateTime.Now.AddDays(2).ToShortDateString();
zametka4.DateTime = DateTime.Now.AddDays(2);
zametka4.position = 1;

Plan zametka5 = new Plan();
zametka5.name = "Do house work";
zametka5.description = "In my room, in living room, in the kitchen";
zametka5.date = DateTime.Now.AddDays(2).ToShortDateString();
zametka5.DateTime = DateTime.Now.AddDays(2);
zametka5.position = 2;

Plan zametka6 = new Plan();
zametka6.name = "Do C#";
zametka6.description = "Zhopnaya zadacha";
zametka6.date = DateTime.Now.ToShortDateString();
zametka6.DateTime = DateTime.Now.Date;
zametka6.position = 3;

List<Plan> plans = new List<Plan>();
plans.Add(zametka1);
plans.Add(zametka2);
plans.Add(zametka3);
plans.Add(zametka4);
plans.Add(zametka5);
plans.Add(zametka6);

int days_to_add = 0;


strelochki(plans, days_to_add);

static void menu_page(List<Plan> plans, int days_to_add)
{
    string date_to_output = DateTime.Now.AddDays(days_to_add).ToShortDateString();
    Console.WriteLine("Выбрана дата " + date_to_output);
    int number = 0;
    foreach (Plan plan in plans)
    {
        if (plan.date == date_to_output)
        {
            number ++;
            Console.WriteLine("  " + number + '.' + ' ' + plan.name);
            

        }
    }
}
static void strelochki(List<Plan> plans, int days_to_add, int position=1)
{
    menu_page(plans, days_to_add);
    while (true)
    {
        int max_position = 0;

        foreach (Plan plan in plans)
        {
            if (plan.date == DateTime.Now.AddDays(days_to_add).ToShortDateString())
            {
                max_position++;
            }
        }

        ConsoleKeyInfo klavisha = Console.ReadKey();

        if (klavisha.Key == ConsoleKey.UpArrow)
        {
            if (position - 1 == 0)
            {
                position = 1;
            }
            else
            {
                position--;

            }

        }
        else if (klavisha.Key == ConsoleKey.DownArrow)
        {
            if (position + 1 > max_position)
            {
                position = 1;


            }
            else
            {
                position++;

            }

        }
        else if (klavisha.Key == ConsoleKey.LeftArrow)
        {
            days_to_add--;
            position = 1;
            Console.Clear();
            foreach (Plan plan in plans)
            {
                if (plan.date == DateTime.Now.AddDays(days_to_add).ToShortDateString())
                {
                    max_position++;
                }
            }
            menu_page(plans, days_to_add);

        }
        else if (klavisha.Key == ConsoleKey.RightArrow)
        {
            days_to_add++;
            position = 1;
            Console.Clear();
            foreach (Plan plan in plans)
            {
                if (plan.date == DateTime.Now.AddDays(days_to_add).ToShortDateString())
                {
                    Console.WriteLine(plan.date);
                    max_position++;
                }
            }
        }
        Console.Clear();
        menu_page(plans, days_to_add);
        Console.SetCursorPosition(0, position);
        Console.WriteLine("->");
        Console.SetCursorPosition(0, position);

        if (klavisha.Key == ConsoleKey.Enter)
        {

            discription(days_to_add, plans, position);

        }
        if (klavisha.Key == ConsoleKey.Escape)
        {
            break;
        }
    }
}
static void discription(int days_to_add, List<Plan> plans, int cursor_position)
{
    foreach (Plan plan in plans)
    {
        if (plan.date == DateTime.Now.AddDays(days_to_add).ToShortDateString())
        {
            if (plan.position == cursor_position)
            {
                Console.Clear();
                Console.WriteLine(plan.name);
                Console.WriteLine("------------------------");
                Console.WriteLine("Описание: " + plan.description);
                Console.WriteLine("Дата: " + plan.DateTime);
            }
        }
    }

}


