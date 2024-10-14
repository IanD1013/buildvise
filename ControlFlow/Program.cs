//int dayOfWeek = 4;
//switch (dayOfWeek)
//{
//    case 1:
//        Console.WriteLine("Monday");
//        break;
//    case 2:
//        Console.WriteLine("Tuesday");
//        break;
//    default:
//        Console.WriteLine("Invalid day");
//        break;
//}


//int dayOfWeek = 4;
//switch (dayOfWeek)
//{
//    case 1:
//    case 2:
//    case 3:
//    case 4:
//    case 5:
//        Console.WriteLine("Week Day");
//        // return;
//        break;
//    case 6:
//    case 7:
//        Console.WriteLine("Weekend");
//        break;
//    default:
//        Console.WriteLine("Invalid day");
//        break;
//}

string dayOfWeekName = "Thursday";
string result = dayOfWeekName switch
{
    "Monday" => "First day of the week",
    "Tuesday" => "Second day of the week",
    "Wednesday" => "Third day of the week",
    "Thursday" => "Fourth day of the week",
    "Friday" => "Fifth day of the week",
    "Saturday" => "Sixth day of the week",
    "Sunday" => "Seventh day of the week",
    _ => "Invalid day"
};
