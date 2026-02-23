using System;
namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Display system info
            Console.WriteLine("Windows version: {0}", Environment.OSVersion);
            Console.WriteLine("64 Bit operating system? : {0}", Environment.Is64BitOperatingSystem ? "Yes" : "No");
            Console.WriteLine("PC Name : {0}", Environment.MachineName);
            Console.WriteLine("Number of CPUS : {0}", Environment.ProcessorCount);
            Console.WriteLine("Windows folder : {0}", Environment.SystemDirectory);
            Console.WriteLine("Logical Drives Available : {0}", String.Join(", ", Environment.GetLogicalDrives()).Replace("\\", "").TrimEnd(',', ' '));
            // 2.shapes information (shapes name and thier sides)
            Console.WriteLine("Shape1: Circle (sides: 1)");
            Console.WriteLine("Shape2: Cylinder (sides: 2)");
            Console.WriteLine("Shape3: Triangle (sides: 3)");
            Console.WriteLine("Shape4: Quadrilateral (sides: 4)");
            Console.WriteLine("Shape5: Pentagon (sides: 5)");
            // 3. Ask for number of questions 
            int numberOfQuestions = 0; // Definition a variable to store the number of question 
            bool validInput = false; // boolean variable to check if the input is valid
            while (!validInput) // repeat until the user enters a valid input
            {
                Console.WriteLine("Please enter the maximum number of questions (should be integer > 0 ):"); // ask the user to enter the number of questions 
                string input = Console.ReadLine(); // read the input as a string
                bool isNumeric = true; //variable to check if the input contains only digits
                int length = input.Length; // get the length of the input string
                for (int i = 0; i < length; i++) // check each character to make sure it's a digi (0-9)
                {
                    if (input[i] < '0' || input[i] > '9')
                    {
                        // if a non-digit character  is found mark input as invalid
                        isNumeric = false;
                        break;
                    }
                }
                // if the input contains only didits and is not empty
                if (isNumeric && length > 0)
                {
                    numberOfQuestions = int.Parse(input); // convert the string to an integer
                    if (numberOfQuestions >= 1 && numberOfQuestions <= 10) // check if the number is whithin the allowed rang (1-10)
                    {
                        // valid input exit the loop
                        validInput = true;
                    }
                    else
                    {
                        // if number is outside the range ask again
                        Console.WriteLine("The number of questions should be an integer > 0, please enter it again:");
                    }
                }
                else
                {
                    // if input is not numberic ask again
                    Console.WriteLine("The number of questions should be an integer > 0, please enter it again: ");
                }
            }

            // 4. Ask for user info (must contain letters + digits or symbols)
            string acceptedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789/?\\"; // define a stringthat contains all accepted charcters (letters, digits ,and some digits)
            string userInfo; // varible to store the user input 

            while (true) // start an infinite loop until the user enters a valid input 
            {
                // ask the user to enter their full name and ID number 
                Console.WriteLine("please enter your name (first name and last name) and your SOU id number and with a space between each part (Accepted Chars: A-Z a-z 0-9 ? / \\)");
                userInfo = Console.ReadLine(); // read the user input from the console
                int acceptedcount = 0; // counter for the number of accepted characters found in the input 
                int len = userInfo.Length; // get the length of the input
                //loop through each character entered by the user 
                for (int i = 0; i < len; i++)
                {
                    char c = userInfo[i];
                    // check if the character is one of the accepted characters 
                    for (int j = 0; j < acceptedChars.Length; j++)
                    {
                        if (c == acceptedChars[j])
                        {
                            acceptedcount++; // count valid characters
                            break; // stop checking once a match is found 
                        }
                    }
                }
                // if the user input contains at least 6 accepted characters 
                if (acceptedcount >= 6)
                {
                    Console.WriteLine("Your full name and id and ...: " + userInfo);

                    // Show distinct accepted characters
                    string distinct = ""; // create a string to store distinct (unique) accepted characters
                    //go through each character again to find distinct accepted characters
                    for (int i = 0; i < len; i++)
                    {
                        char c = userInfo[i];
                        bool isAccepted = false;
                        // check if character is accepted
                        for (int j = 0; j < acceptedChars.Length; j++)
                        {
                            if (c == acceptedChars[j])
                            {
                                isAccepted = true;
                                break;
                            }
                        }

                        if (isAccepted)
                        {
                            bool alreadyExists = false;
                            // check if the character already exists in 'distinct' 
                            for (int k = 0; k < distinct.Length; k++)
                            {
                                if (distinct[k] == c)
                                {
                                    alreadyExists = true;
                                    break;
                                }
                            }
                            // add the character to 'distinct' only if it's not already there
                            if (!alreadyExists)
                            {
                                distinct += c;
                            }
                        }
                    }
                    // display the distinct accepted characters used by the user
                    Console.WriteLine("Distinct Chars are : " + distinct);
                    break; // exit the loop (input is valid)
                }
                else
                {
                    // if input dosen't have at least 6 accepted characters ask again
                    Console.WriteLine("The entered text should contain at least 6 of Accepted chars.");
                }

            }
            // 5. Ask user to propose a shape( inpute is expected from the given options)
            Console.WriteLine("Enter proposed shape name (Circle, Cylinder, Triangle, Quadrilateral, Pentagon):");
            // read the shape name entered by the user and convert it to lowercase for easy comparison
            string proposedShape = Console.ReadLine().ToLower();
            // ask the user to enter the number of sides of the shape
            Console.WriteLine("Enter number of sides:");
            string sidesInput = Console.ReadLine();
            // covert the input string to an integer value 
            int sides = int.Parse(sidesInput);
            // create an arry tostore the lengths of all sides
            int[] sideLengths = new int[sides];
            // ask the user to enter the length of each side
            Console.WriteLine("Enter side lengths:");
            // loop through each side to collect its lenght
            for (int i = 0; i < sides; i++)
            {
                Console.Write("Side " + (i + 1) + ":");  // display which side the user is currently entering (e.g. "side :1")
                sideLengths[i] = int.Parse(Console.ReadLine()); // read the user's input and convert it from string to integer
            }

            // 6. Generate questions
            // array containing possible shape names 
            string[] shapeNames = { "circle", "cylinder", "triangle", "quadrilateral", "pentagon" };
            // array  containing the corresponding number of sides for each shape
            int[] shapeSides = { 1, 2, 3, 4, 5 };
            // create a random object to generate random numbers
            Random rand = new Random();
            // arrays to store information for each question:
            string[] actualShapes = new string[numberOfQuestions]; // the real (randomly chosen) shape
            string[] suggestedNames = new string[numberOfQuestions]; // the suggested shape name (may be wrong)
            int[] actualTotals = new int[numberOfQuestions]; // total of all side lengths
            bool[] validities = new bool[numberOfQuestions]; // wether the actual shape is valid
            int[] userScores = new int[numberOfQuestions]; // user score per question
                                                           // loop through each question (based on the number  enterd earlier)
            for (int q = 0; q < numberOfQuestions; q++)
            {
                // pick a random shape
                int shapeIndex = rand.Next(0, shapeNames.Length);
                string actualShape = shapeNames[shapeIndex];
                int actualSideCount = shapeSides[shapeIndex];
                // create an array for the side lengths of this shape
                int[] actualSideLengths = new int[actualSideCount];
                int actualTotal = 0;
                // generate random side lengths (1 to 20) and calculate their total 
                for (int i = 0; i < actualSideCount; i++)
                {
                    actualSideLengths[i] = rand.Next(1, 21);
                    actualTotal += actualSideLengths[i];
                }
                // randomly pick a "suggested" shape name (may or may not match the actual one)
                string suggestedName = shapeNames[rand.Next(0, shapeNames.Length)];
                bool isActuallyValid = CheckShapeValidity(actualShape, actualSideLengths);
                // save information for later use
                actualShapes[q] = actualShape;
                suggestedNames[q] = suggestedName;
                actualTotals[q] = actualTotal;
                validities[q] = isActuallyValid;
                // display question details to the user 
                Console.WriteLine("\nQuestion " + (q + 1));
                Console.WriteLine("Suggested shape: " + suggestedName);
                Console.Write("Side lengths: ");
                for (int i = 0; i < actualSideCount; i++)
                {
                    Console.Write(actualSideLengths[i] + " ");
                }
                Console.WriteLine();
                // ask user to enter the total length of all sides or choose to ignore
                Console.WriteLine("Enter total length of sides (or type 'ignore'):");
                string input = Console.ReadLine().ToLower();
                // if the user chooses to ignore this question
                if (input == "ignore")
                {
                    userScores[q] = 1; // give minimal score
                    Console.WriteLine("Question ignored.");
                    continue; // move to the next question
                }
                // convert the entered total to an integer
                int userTotal = int.Parse(input);
                // ask if the user thinks the shape is valid 
                Console.WriteLine("Is the shape valid? (1 for Yes, 2 for No):");
                int validAnswer = int.Parse(Console.ReadLine());
                bool userValid = (validAnswer == 1);
                // ask if user thinks the suggested shape name is correct
                Console.WriteLine("Is the suggested name correct? (1 for Yes, 2 for No):");
                int nameInput = int.Parse(Console.ReadLine());
                bool userNameCorrect = (nameInput == 1);
                //start with a base score of 1 point for participation
                int score = 1;
                // add points for each correct answer
                if (userTotal == actualTotal) score++; // correct total
                if (userValid == isActuallyValid) score++; // correct validity
                bool isNameActuallyCorrect = (suggestedName == actualShape); // compare actual vs suggested name
                if (userNameCorrect == isNameActuallyCorrect) score++; // correct shape name 
                // save and show the user's score
                userScores[q] = score;
                Console.WriteLine("Answer recorded. Score: " + score + "/4");

            }
            // 7.start of the menu section
            string choice;
            do
            {
                // display the menu options fir the user
                Console.WriteLine("choose a number to show information: ");
                Console.WriteLine("\n1. Evaluate your proposed shape");
                Console.WriteLine("2. Show actual shapes");
                Console.WriteLine("3. Count fully wrong answers");
                Console.WriteLine("4. Count fully correct answers");
                Console.WriteLine("5. Count partially correct answers");
                Console.WriteLine("6. Show all answers and comparisons");
                Console.WriteLine("7. Quit");
                Console.Write("Your choice: ");
                choice = Console.ReadLine().ToLower();
                // switch block to execute the user's selected option 
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Your shape: " + (proposedShape) + "Sides: " + (sides));
                        break;
                    case "2":
                        Console.WriteLine("Actual shapes:");
                        for (int i = 0; i < numberOfQuestions; i++)
                        {
                            Console.WriteLine("Q" + (i + 1) + " : " + (actualShapes[i]));
                        }
                        break;
                    case "3":
                        CountFullyWrongAnswers(userScores, numberOfQuestions);
                        break;
                    case "4":
                        CountFullyCorrectAnswers(userScores, numberOfQuestions);
                        break;
                    case "5":
                        CountPartiallyCorrectAnswers(userScores, numberOfQuestions);
                        break;
                    case "6":
                        ShowAllAnswers(actualShapes, suggestedNames, actualTotals, validities, userScores, numberOfQuestions);
                        break;
                    case "7":
                    case "quit":
                        // exit message 
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != "7" && choice != "quit");
            // 8.SUPPORTING FUNCTIONS SECTION
            //check if a shape is valid based on its type and side lengths 
        }

        static bool CheckShapeValidity(string shape, int[] sides)
        {
            //  add logical OR operater (||)
            if (shape == "circle" || shape == "cylinder")
            {
                // a circle or cylinder is considered valid if the single side length >=4
                return sides[0] >= 4;
            }
            else
            {
                // check tringle inquality 9sum of other sides > each side)
                for (int i = 0; i < sides.Length; i++)
                {
                    int sumOtherSides = 0;
                    for (int j = 0; j < sides.Length; j++)
                    {
                        if (j != i) sumOtherSides += sides[j];
                    }
                    if (sides[i] >= sumOtherSides)
                        return false; // invalid if any side is too long 
                }
                return true; // valid if all checks passed

            }

        }
        // function to count wrong answers
        static void CountFullyWrongAnswers(int[] userScores, int count)
        {
            int wrong = 0;
            for (int i = 0; i < count; i++)
            {
                if (userScores[i] == 1) wrong++;
            }
            Console.WriteLine("Fully wrong answers: " + (wrong) / (count));
        }
        // function to count correct ancwers
        static void CountFullyCorrectAnswers(int[] userScores, int count)
        {



            int correct = 0;
            for (int i = 0; i < count; i++)
            {
                if (userScores[i] == 4) correct++;
            }
            Console.WriteLine("Fully correct answers: " + (correct) / (count));
        }
        // function to count partially correct answers
        static void CountPartiallyCorrectAnswers(int[] userScores, int count)
        {
            int partial = 0;
            for (int i = 0; i < count; i++)
            {
                if (userScores[i] == 2 || userScores[i] == 3) partial++;
            }
            Console.WriteLine("Partially correct answers: " + (partial) / (count));
        }
        // function to show all answers and compaisons 
        static void ShowAllAnswers(string[] actualShapes, string[] suggestedNames, int[] actualTotals, bool[] validities, int[] userScores, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Q" + (i + 1) + ": Actual= " + (actualShapes[i]) + "  " + " Suggested= " + (suggestedNames[i]) + " " + "Total= " + (actualTotals[i]) + " " + "Valid= " + (validities[i]) + " " + "Score= " + (userScores[i]) / 4);
            }


        }
    }
}
