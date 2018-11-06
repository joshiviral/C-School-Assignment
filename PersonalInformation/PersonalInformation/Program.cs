using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalInformation
{
    class Program
    {
        public static List<Person> PeopleList = new List<Person>();
        public static List<Rooms> RoomList = new List<Rooms>();
        public static int[] roomno;
        public static int[] Availroomno;
        public static List<Person> showMembers(List<Person> roomMember)
        {
            displayData(roomMember);
            return roomMember;
        }
        public static List<Person> DisplayInformation(List<Person> toDisplayData)
        {
            Console.Clear();
            int choice = 0;               
            do
            {
                Console.WriteLine("\nSelect option to show results");
                Console.WriteLine("1. All data");
                Console.WriteLine("2. Personal");
                Console.WriteLine("3. Family");
                Console.WriteLine("4. Friends");
                Console.WriteLine("5. Back to main menu\n");
               try
                {
                    choice = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input, Check your input please");
                }


                switch (choice)
                {
                    case 1:
                        displayData(toDisplayData);
                        break;
                    case 2:
                        var personalData = from f in toDisplayData
                                           where f.type == "Personal"
                                           select f;
                        displayData(personalData);
                        break;
                    case 3:
                        var familyData = from fd in toDisplayData
                                         where fd.type == "Family"
                                         select fd;
                        displayData(familyData);
                        break;
                    case 4:
                        var friendData = from ad in toDisplayData
                                         where ad.type == "Friend"
                                         select ad;
                        displayData(friendData);
                        break;
                    default:
                        break;


                }
            } while (choice!=5);
            Console.Clear();
            return toDisplayData;
        }
        public static void displayData(IEnumerable<Person> list)
        {
            roomno = new int[list.Count()];
            Console.WriteLine("\n**********Information**********\n");
            int i = 0;
            foreach (Person person in list)
            {
                roomno[i] = person.roomNo;
                             i++;
                Console.WriteLine("\nRoom No: "+person.roomNo+"\nPersonID: " + person.PersonId + "\nPersonType: " + person.type + "\nFirstName: " + person.FirstName + "\nMiddleName: " + person.MiddleName + "\nLastName: " + person.LastName +"\nEmailAddress: "+ person.EmailAddress+"\nCity: "+ person.City+"\nAddress: "+person.address+"\nPhoneNumber: "+person.phoneNummber);
            }
            Availroomno = roomno.Distinct().ToArray();
        }


        public static Person[] CreateInformation()
        {
            
            int typeChoice = 0;
            int numOfRecords= 0;
            do
            {
                Console.WriteLine("Choose category to enter information");
                Console.WriteLine("1). Family");
                Console.WriteLine("2). Friends");
                Console.WriteLine("3). Yourself");
                Console.WriteLine("4). Back to main menu");
                Console.Write("Enter your option: ");
                typeChoice = Convert.ToInt16(Console.ReadLine());
                
                /** Initialize list to null to solve scope problem (Problem while returning list array) **/            
                Person[] peopleArray = null;
                Console.WriteLine("Please enter how many people you are entering ");
                
                try
                {
                    numOfRecords = Convert.ToInt16(Console.ReadLine());
                    peopleArray = new Person[numOfRecords];
                    for (int i = 0; i < numOfRecords; i++)
                    {
                        peopleArray[i] = new Person(1,"", "", "", "", "", "","","");
                        switch (typeChoice)
                        {
                            case 1:
                                peopleArray[i].type = "Personal";                                
                                break;

                            case 2:                                
                                peopleArray[i].type = "Friend";                                
                                break;
                            case 3:
                                peopleArray[i].type = "Family";                                
                                break;
                        }
                        Console.Write("Enter room number to where he is living");
                        peopleArray[i].roomNo = Convert.ToInt16(Console.ReadLine());

                        Console.Write("Enter Firstname:");
                        peopleArray[i].FirstName = Console.ReadLine();

                        Console.Write("\nEnter Middlename as initial: ");
                        peopleArray[i].MiddleName = Console.ReadLine();

                        Console.Write("\nEnter Lastname: ");
                        peopleArray[i].LastName = Console.ReadLine();

                        Console.Write("\nEnter Emailaddress: ");
                        peopleArray[i].EmailAddress = Console.ReadLine();

                        Console.Write("\nEnter Home Address:");
                        peopleArray[i].address = Console.ReadLine();

                        Console.Write("\nEnter Phonenumber: ");
                        peopleArray[i].phoneNummber = Console.ReadLine();

                        Console.Write("\nEnter City: ");
                        peopleArray[i].City = Console.ReadLine();

                        if (peopleArray[i].type == "Friend")
                        {
                          
                            peopleArray[i] = new Friends(peopleArray[i].roomNo,peopleArray[i].type, peopleArray[i].FirstName, peopleArray[i].MiddleName, peopleArray[i].LastName, peopleArray[i].EmailAddress, peopleArray[i].City, peopleArray[i].address, peopleArray[i].phoneNummber);
                        }
                        else if (peopleArray[i].type == "Family")
                        {
                            peopleArray[i] = new Family(peopleArray[i].roomNo,peopleArray[i].type, peopleArray[i].FirstName, peopleArray[i].MiddleName, peopleArray[i].LastName, peopleArray[i].EmailAddress, peopleArray[i].City, peopleArray[i].address, peopleArray[i].phoneNummber);
                        }
                        else
                        {
                            peopleArray[i] = new Personal(peopleArray[i].roomNo,peopleArray[i].type, peopleArray[i].FirstName, peopleArray[i].MiddleName, peopleArray[i].LastName, peopleArray[i].EmailAddress, peopleArray[i].City, peopleArray[i].address, peopleArray[i].phoneNummber);
                        }
                        PeopleList.Add(peopleArray[i]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input, Check your input please");
                }
               
                Console.Clear();
                
                return peopleArray;
            } while (typeChoice != 4);
        }

       
        private static List<Person> fillData(List<Person> PeopleList)
        {            
            List<Person> testSubjects = new List<Person>();
            testSubjects = PeopleList;
            testSubjects.Add(new Person(1,"Friend", "Milan", "P", "Kyada", "milankyada@gmail.com", "Howler City","553, vanier Dr","4379822221") { });
            testSubjects.Add(new Person(2,"Friend", "Manoj", "P", "Kyada", "mak@gmail.com", "Phipsburg", "553, vanier Dr", "4379822221") { });
            testSubjects.Add(new Person(3,"Friend", "Vimal", "A", "Gajera", "vimalgajera@gmail.com", "Bangor", "553, vanier Dr", "4379822221") { });
            testSubjects.Add(new Person(4,"Personal", "Akash", "R", "Kachhadiya", "aka.kach@gmail.com", "Kitchener", "553, vanier Dr", "4379822221") { });
            testSubjects.Add(new Person(5,"Family", "Race", "D", "Dhiyad", "race@gmail.com", "Kitchener", "553, vanier Dr", "4379822221") { });
            return testSubjects;
        }     
        public static bool found = false;
        public static List<Person> findMember(List<Person> toDisplayData,int rid,string memName)
        {
            var personalData = from f in toDisplayData
                               where f.roomNo == rid && f.FirstName==memName
                               select f;
            if (personalData.Count() > 0)
            {
                Console.WriteLine("Found your member. He is in room: {0}",rid);
                found = true;
            }
                        return toDisplayData;
        }
        public static void checkRoom(string memName)
        {
            Console.WriteLine("You're in  room 1");
            int i = 1;
            if (i == 1)
            {
                findMember(PeopleList, i, memName);
                if (found)
                {
                    Console.WriteLine("Found here");
                }
                else
                {
                    goto there;
                }
            }
            there:
            {
                do
                {
                    Console.WriteLine("Move or exit? (write m or q)");
                    string c = Console.ReadLine();
                    if (c == "m" || c=="M")
                    {
                        i++;
                        Console.WriteLine("Enter Room number");
                        int rNo = Convert.ToInt16(Console.ReadLine());
                        if (rNo == i)
                        {
                            Console.WriteLine("You're in same room");
                        }
                        else
                        {
                            findMember(PeopleList, rNo, memName);
                        }

                    }
                    else if (c == "q"||c == "Q")
                    {
                        Environment.Exit(0);
                    }
                } while (!found);
                
            }
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("#########################################");
            Console.WriteLine("#        Choose operation               #");
            Console.WriteLine("#########################################");
            Console.WriteLine();
            int choice = 0;          
            fillData(PeopleList);
            do
            {
                Console.WriteLine("1). Enter new information");
                Console.WriteLine("2). Display information ");
                Console.WriteLine("3). Quit");
                Console.WriteLine("4). Search in room");
                //Console.WriteLine("5). S")
                Console.Write("Enter your option: ");
                try
                {
                    choice = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            CreateInformation();
                            break;
                        case 2:
                            DisplayInformation(PeopleList);
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        case 4:
                            showMembers(PeopleList);
                            Console.WriteLine("Available rooms: ");
                            for (int i = 0; i < Availroomno.Length; i++)
                            {
                                Console.Write(Availroomno[i] + " ");
                            }
                            Console.WriteLine("Enter member name to search:");
                            string memberName = Console.ReadLine();
                            checkRoom(memberName);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input, Check your input please\n");
                }                
            } while (choice != 0);
            Console.ReadLine();
        }
    }
}