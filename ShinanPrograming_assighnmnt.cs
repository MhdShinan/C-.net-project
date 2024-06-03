using System.Collections;

struct Member
{
    public string MemberName;
    public int CostInAMonth;
    public int TotalCost;
}

struct CoachingPlan
{
    public string CoachingPlanName;
}

struct Weight
{
    public int WeightValue;
}

struct NoOfMatchesPlayed
{
    public int MatchesPlayed;
}

struct NoOfCoachingHoursRequired
{
    public int NoOfCoachingHours;
}

class MemberManagementSystem
{
    private static ArrayList members = new ArrayList();
    private static bool running = true;
    private static List<Member> Members = new List<Member>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Madzoo Digital system");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("");

        while (running)
        {
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. Quit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine("");

            switch (choice)
            {
                case "1":
                    RegisterNewMember();
                    break;
                case "2":
                    running = false;
                    break;
                default:
                    Console.WriteLine($"Invalid Command: {choice}");
                    break;
            }
        }
    }

    static void RegisterNewMember()
    {
        Console.WriteLine("");
        Console.WriteLine("Please enter member details:");

        Console.Write("1) Enter Member Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("");

        Console.WriteLine("..................");
        Console.Write("1.1) Cost in a month: ");
        int costInAMonth = Convert.ToInt32(Console.ReadLine());

        Console.Write("1.2) Total cost: ");
        int totalCost = Convert.ToInt32(Console.ReadLine());

        Console.Write("1.3) Coaching plan: ");
        string coachingPlanName = Console.ReadLine();
        Console.WriteLine("..................");

        Console.WriteLine("");

        int weight = 0;

        while (true)
        {
            Console.Write("2) Enter weight in kilograms (1-300): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out weight) && weight >= 1 && weight <= 300)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 300.");
            }
        }

        Console.WriteLine("Weight: " + weight + " kg");
        Console.WriteLine("");

        Console.Write("3) No of matches played: ");
        int matchesPlayed = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        Console.Write("4) Coaching hours required: ");
        int noOfCoachingHoursRequired = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        Console.WriteLine("Membership Types:");
        Console.WriteLine("1. Individual (Adult over 18 years)");
        Console.WriteLine("2. Family (2 adults and any number of children)");
        Console.WriteLine("3. Junior/Intermediate (Full-time student up to age 25)");
        Console.WriteLine();

        Console.Write("5) Enter membership type (1-3): ");
        int membershipType = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        Console.WriteLine("Membership Durations:");
        Console.WriteLine("1. Annual");
        Console.WriteLine("2. 6 months");
        Console.WriteLine("3. 3 months");
        Console.WriteLine("4. 1 month");
        Console.WriteLine();

        Console.Write("6) Enter membership duration (1-4): ");
        int membershipDuration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        int membershipFee = CalculateMembershipFee(membershipType, membershipDuration);

        Console.WriteLine("7) Membership Fee: {0} LKR", membershipFee);
        Console.WriteLine("");

        int coachingFeePerHour = 1000;
        int matchEntryFee = 1500;
        int maxCoachingHoursPerWeek = 4;

        try
        {
            Console.Write("8) Enter the number of coaching hours per week between 0 and 4: ");
            int coachingHours = Convert.ToInt32(Console.ReadLine());

            if (coachingHours < 0 || coachingHours > maxCoachingHoursPerWeek)
            {
                Console.WriteLine("Invalid input! The number of coaching hours must be between 0 and 4.");
            }
            else
            {
                int coachingFeePerHourValue = 50;
                int matchEntryFeeValue = 100;
                int coachingHoursValue = 10;
                int coachingFees = coachingFeePerHourValue * coachingHours;
                int totalFees = coachingFees + matchEntryFee;
                Console.WriteLine("9) Coaching Fees Breakdown");
                Console.WriteLine("..................");
                Console.WriteLine("9.1) Coaching Fee per hour: " + coachingFeePerHourValue.ToString("F0") + " LKR");
                Console.WriteLine("9.2) Match Entry Fee: " + matchEntryFeeValue.ToString("F0") + " LKR");
                Console.WriteLine("9.3) Total Coaching Hours per week: " + coachingHours);
                Console.WriteLine("9.4) Total Coaching Fees: " + coachingFees.ToString("F0") + " LKR");
                Console.WriteLine("9.5) Total Fees (including match entry): " + totalFees.ToString("F0") + " LKR");
                Console.WriteLine("..................");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
        finally
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Successfully added New member");
            Console.WriteLine("----------------------------");
        }
    }

    static int CalculateMembershipFee(int membershipType, int membershipDuration)
    {
        Int32 fee = 0;

        switch (membershipDuration)
        {
            case 1: // Annual
                switch (membershipType)
                {
                    case 1:
                        fee = 5000;
                        break;
                    case 2:
                        fee = 7000;
                        break;
                    case 3:
                        fee = 3000;
                        break;
                }
                break;
            case 2: // 6 months
                switch (membershipType)
                {
                    case 1:
                        fee = 3000;
                        break;
                    case 2:
                        fee = 5000;
                        break;
                    case 3:
                        fee = 2000;
                        break;
                }
                break;
            case 3: // 3 months
                switch (membershipType)
                {
                    case 1:
                        fee = 2500;
                        break;
                    case 2: // Family
                        fee = 3500;
                        break;
                }
                break;
            case 4: // 1 month
                switch (membershipType)
                {
                    case 1:
                        fee = 2000;
                        break;
                    case 2:
                        fee = 2500;
                        break;
                }
                break;
        }

        return fee;
    }
}
