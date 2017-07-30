using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace JHS_CSS_APP
{
    class Program
    {
        // uses c# built in function to set the window position to center
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr MyConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        private const int SW_HIDE = 0;
        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;
        private const int SW_RESTORE = 9;
        private const int SWP_NOSIZE = 0x0001;

        private static Students firstYearStudents = new Students();
        private static Students secondYearStudents = new Students();
        private static Students thirdYearStudents = new Students();
        private static Students fourthYearStudents = new Students();

        static void Main(string[] args)
        {
            ConfigWindow();
            ConfigApp();
            RunApp();
            

            // create folder
            //Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Student");

            //// creates the files if the file does not exists else it reads the specified file
            //FileStream input = new FileStream("hello.txt", FileMode.OpenOrCreate, FileAccess.Read);
            //StreamReader fin = new StreamReader(input);
            
            //while (!fin.EndOfStream)
            //{
            //    string r = fin.ReadLine();
            //    Console.WriteLine(r);
            //}

            //fin.Close();

            //FileStream output = new FileStream("hi.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //StreamWriter fout = new StreamWriter(output);
            //fout.WriteLine("HELLO WORLD!!!");
            //fout.Close();
            
            
            Console.ReadKey();
        }
        #region HelpMethods

            public static void RunApp()
            {
                Console.Clear();
                Display.DisplayMainMenu();
                switch (GetMenuChoice())
                {
                    case 'a':
                        DisplayStudentMenu();
                        break;
                    case 'b':
                        SectionModule();
                        break;
                    case 'c':
                        string str = "Thank you for using our program";
                        Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 30);
                        Console.Write(str);
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        return;
                }
            }

            public static void ConfigWindow()
            {
                Console.Title = "JHS_CSS_APP";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.White;
                SetWindowPos(MyConsole, 0, 0, 0, 0, 0, SWP_NOSIZE);
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            }

            public static void ConfigApp()
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Students");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Sections");

                string studentsDirectory = Directory.GetCurrentDirectory() + "/Students/";
                CopyStudents(studentsDirectory + "FirstYear.lst", 1);
                CopyStudents(studentsDirectory + "SecondYear.lst", 2);
                CopyStudents(studentsDirectory + "ThirdYear.lst", 3);
                CopyStudents(studentsDirectory + "FourthYear.lst", 4);
            }


            public static void CopyStudents(string path, int yearLevel)
            {
                FileStream input = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader fin = new StreamReader(input);

                while (!fin.EndOfStream)
                {
                    string r = fin.ReadLine();
                    string[] studentInfo = r.Split('|');

                    switch (yearLevel)
                    {
                        case 1:
                            firstYearStudents.Add(new Student(studentInfo[0], yearLevel, studentInfo[1],
                                studentInfo[3], studentInfo[2], Convert.ToDateTime(studentInfo[5]), studentInfo[4][0]));
                            break;
                        case 2:
                            firstYearStudents.Add(new Student(studentInfo[0], yearLevel, studentInfo[1],
                                studentInfo[3], studentInfo[2], Convert.ToDateTime(studentInfo[5]), studentInfo[4][0]));
                            break;
                        case 3:
                            firstYearStudents.Add(new Student(studentInfo[0], yearLevel, studentInfo[1],
                                studentInfo[3], studentInfo[2], Convert.ToDateTime(studentInfo[5]), studentInfo[4][0]));
                            break;
                        case 4:
                            firstYearStudents.Add(new Student(studentInfo[0], yearLevel, studentInfo[1],
                                studentInfo[3], studentInfo[2], Convert.ToDateTime(studentInfo[5]), studentInfo[4][0]));
                            break;
                    }
                }
            }

            public static bool isBack(int col, int row)
            {
                bool isCorrect = false;
                string choice;
                do
                {
                    Console.SetCursorPosition(col, row);
                    Console.Write("Return back[Y/N]? ");
                    choice = Console.ReadLine().ToString();

                    Console.SetCursorPosition(col, row + 2);
                    if (choice == "")
                        Console.Write("Please input a letter..             ");
                    else if (choice.ToString().ToLower()[0] == 'y' || choice.ToString().ToLower()[0] == 'n')
                        break;
                    else
                        Console.Write("Please enter a correct response     ");

                } while (!isCorrect);

                return (choice.ToLower()[0] == 'y') ? true : false;
            }

            public static char GetMenuChoice()
            {
                string choice = "";

                do
                {
                    string str = "Your choice: ";
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 14, 30);
                    Console.Write(str);

                    choice = Console.ReadLine().ToString();

                    if (choice == "")
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 20, 33);
                        Console.Write("Please input a corect choice..");
                    }
                } while (choice == "");

                return choice.ToLower()[0];
            }

            public static char GetMenuChoice(int left, int top)
            {
                string choice = "";

                do
                {
                    string str = "Your choice: ";
                    Console.SetCursorPosition(left, top);
                    Console.Write(str);

                    choice = Console.ReadLine().ToString();

                    if (choice == "")
                    {
                        Console.SetCursorPosition(left, top + 1);
                        Console.Write("Please input a corect choice..");
                    }
                } while (choice == "");

                return choice.ToLower()[0];
            }


        #endregion

        #region StudentClass
            public static void DisplayStudentMenu()
            {
                Console.Clear();
                Display.DisplayHeader();

                string str = "[ C L A S S S T U D E N T  M E N U ]";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
                Console.WriteLine(str);

                str = "[a]. View All Student";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 12);
                Console.WriteLine(str);

                str = "[b]. Add Student";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 14);
                Console.WriteLine(str);

                str = "[c]. Edit Students";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 16);
                Console.WriteLine(str);

                str = "[d]. Delete Student";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 18);
                Console.WriteLine(str);

                str = "[e]. Back";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 20);
                Console.WriteLine(str);
            }
        public static void ViewAllStudent()
        {
            Console.Clear();
            Display.DisplayHeader();

            string str = "[ C L A S S  S T U D E N T  M E N U ]";
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
            Console.WriteLine(str);

            string currentDirectory = Directory.GetCurrentDirectory() + "/Students";
            string[] files = Directory.GetFiles(currentDirectory);
            ArrayList studentNames = new ArrayList();
            int ctr = 1;
            int rowNo = 12;

            str = "Student List";
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 10);
            Console.WriteLine(str);

            string rowLine = "+----+----------------------------------+";
            string line = "|    |                                  | ";

            Console.SetCursorPosition((Console.WindowWidth - rowLine.Length) / 2, rowNo++);
            Console.WriteLine(rowLine);

            foreach (var file in files)
            {
                string studName = file.Remove(0, currentDirectory.Length + 1);
                studName = studName.Remove(studName.Length - 4);
                studentNames.Add(studName);

                Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, rowNo);
                Console.WriteLine(line);

                Console.SetCursorPosition((Console.WindowWidth / 2) - 19, rowNo);
                Console.WriteLine(ctr.ToString());

                Console.SetCursorPosition((Console.WindowWidth / 2) - 13, rowNo);
                Console.WriteLine(studName);

                rowNo++;
                ctr++;
                Console.SetCursorPosition((Console.WindowWidth - rowLine.Length) / 2, rowNo++);
                Console.WriteLine(rowLine);
            }

            str = "Enter a student name to view the student info or back to return to menu";
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, rowNo + 4);
            Console.WriteLine(str);

            bool isNotOkay = true;

            do
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 6);
                Console.Write("Enter your choice : ");
                string userChoice = Console.ReadLine();

                if (userChoice == "back")
                {
                    isNotOkay = false;
                    StudentModule();
                }
                else
                {
                    bool isPresent = false;
                    foreach (string classStudentName in studentNames)
                    {
                        if (classStudentName == userChoice)
                            isPresent = true;
                    }

                    if (isPresent)
                    {
                        ShowStudentInfo(userChoice);
                        isNotOkay = false;
                    }
                    else
                    {
                        str = "Not listed student name...";
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 8);
                        Console.Write(str);
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 6);
                        Console.Write("                                          ");
                    }

                }
            } while (isNotOkay);
        }
        public static void ShowStudentInfo(string studentNo)
        {
            Console.Clear();
            Display.DisplayHeader();

            string str = "[ C L A S S  S T U D E N T  M E N U ]";
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
            Console.WriteLine(str);

            string currentDirectory = Directory.GetCurrentDirectory() + "/Students/";
            FileStream input = new FileStream(currentDirectory + studentNo + ".sec", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader fin = new StreamReader(input);

            int rowNo = 8;
            bool toCenter = false;
            while (!fin.EndOfStream)
            {
                str = fin.ReadLine();

                if (str == "MALE") toCenter = true;

                if (toCenter)
                    Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, rowNo++);
                else
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo++);

                Console.Write(str);
            }

            if (isBack((Console.WindowWidth / 2) - 20, rowNo + 5))
                ViewAllSection();
            else
                ShowStudentInfo(studentNo);
        }
        public static void StudentModule()
        {
            DisplayStudentMenu();
            switch (GetMenuChoice())
            {
                case 'a':
                    ViewAllStudent();
                    break;
                case 'b':
                    AddStudent();
                    break;
                case 'c':
                    DisplayTeacherMenu();
                    break;
                case 'd':
                    break;
                case 'e':
                    RunApp();
                    break;
            }
        } 
        public static void AddStudent()
        {
            Console.Clear();

            int yearLevel;
            string studentName;
            char studentGender;
            DateTime birthDate;

            string str = "[ S T U D E N T A D D F O R M ]";
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
            Console.WriteLine(str);

            str = "Enter Year Level : ";
            Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 12);
            Console.Write(str);
            yearLevel = Convert.ToInt32(Console.ReadLine());

            str = "Enter Your Name : ";
            Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 14);
            Console.Write(str);
            studentName = Console.ReadLine();

            str = "Enter Your Gender : ";
            Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 12);
            Console.Write(str);
            studentGender = Convert.ToChar(Console.ReadLine());

            str = "Enter Your BirthDate : ";
            Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 12);
            Console.Write(str);
            birthDate = Convert.ToDateTime(Console.ReadLine());

            //addStudentMenu(yearLevel, studentName, studentGender, birthDate);
        }
        public static void addStudentMenu()
        {



        }
        #endregion

        #region ClassSection
            public static void DisplaySectionMenu()
            {
                Console.Clear();
                Display.DisplayHeader();

                string str = "[ C L A S S  S E C T I O N  M E N U ]";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
                Console.WriteLine(str);

                str = "[a]. View All Sections";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 12);
                Console.WriteLine(str);

                str = "[b]. Add Section";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 14);
                Console.WriteLine(str);

                str = "[c]. Edit Section";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 16);
                Console.WriteLine(str);

                str = "[d]. Delete Section";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 18);
                Console.WriteLine(str);

                str = "[e]. Back";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 20);
                Console.WriteLine(str);
            }
            public static void SectionModule()
            {
                DisplaySectionMenu();
                switch (GetMenuChoice())
                {
                    case 'a':
                        ViewAllSection();
                        break;
                    case 'b':
                        AddSection();
                        break;
                    case 'c':
                        EditSection();
                        break;
                    case 'd':
                        DeleteSection();
                        break;
                    case 'e':
                        RunApp();
                        break;
                }
            }
            public static void ViewAllSection()
            {
                Console.Clear();
                Display.DisplayHeader();

                string str = "[ C L A S S  S E C T I O N  M E N U ]";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
                Console.WriteLine(str);

                string currentDirectory = Directory.GetCurrentDirectory() + "/Sections";
                string[] files = Directory.GetFiles(currentDirectory);
                ArrayList sectionNames = new ArrayList();
                int ctr = 1;
                int rowNo = 12;

                str = "Section List";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 10);
                Console.WriteLine(str);

                string rowLine = " +----+----------------------------------+ ";
                string line = "|    |                                  | ";

                Console.SetCursorPosition((Console.WindowWidth - rowLine.Length) / 2, rowNo++);
                Console.WriteLine(rowLine);

                foreach (var file in files)
                {
                    string sectName = file.Remove(0, currentDirectory.Length + 1);
                    sectName = sectName.Remove(sectName.Length - 4);
                    sectionNames.Add(sectName);

                    Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, rowNo);
                    Console.WriteLine(line);

                    Console.SetCursorPosition((Console.WindowWidth / 2) - 19, rowNo);
                    Console.WriteLine(ctr.ToString());

                    Console.SetCursorPosition((Console.WindowWidth / 2) - 13, rowNo);
                    Console.WriteLine(sectName);

                    rowNo++;
                    ctr++;
                    Console.SetCursorPosition((Console.WindowWidth - rowLine.Length) / 2, rowNo++);
                    Console.WriteLine(rowLine);
                }

                str = "Enter a section name to view the section info or back to return to menu";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, rowNo + 4);
                Console.WriteLine(str);

                bool isNotOkay = true;

                do
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 6);
                    Console.Write("Enter your choice : ");
                    string userChoice = Console.ReadLine();

                    if (userChoice == "back")
                    {
                        isNotOkay = false;
                        SectionModule();
                    }
                    else
                    {
                        bool isPresent = false;
                        foreach (string classSectionName in sectionNames)
                        {
                            if (classSectionName == userChoice)
                                isPresent = true;
                        }

                        if (isPresent)
                        {
                            ShowSectionInfo(userChoice);
                            isNotOkay = false;
                        }
                        else
                        {
                            str = "Invalid section name...";
                            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 8);
                            Console.Write(str);
                            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 6);
                            Console.Write("                                          ");
                        }

                    }
                } while (isNotOkay);
            }
            public static void ShowSectionInfo(string sectionID)
            {
                Console.Clear();
                Display.DisplayHeader();

                string str = "[ C L A S S  S E C T I O N  M E N U ]";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
                Console.WriteLine(str);

                string currentDirectory = Directory.GetCurrentDirectory() + "/Sections/";
                FileStream input = new FileStream(currentDirectory + sectionID + ".sec", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader fin = new StreamReader(input);

                int rowNo = 8;
                bool toCenter = false;
                while (!fin.EndOfStream)
                {
                    str = fin.ReadLine();

                    if (str == "MALE") toCenter = true;

                    if (toCenter)
                        Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, rowNo++);
                    else
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo++);

                    Console.Write(str);
                }

                if (isBack((Console.WindowWidth / 2) - 20, rowNo + 5))
                    ViewAllSection();
                else
                    ShowSectionInfo(sectionID);
            }
            public static void AddSection()
            {
                Console.Clear();
                Display.DisplayHeader();

                int yearLevel;
                string sectionName;
                string teacherName;
                ArrayList students = new ArrayList();

                string str = "[ C L A S S  S E C T I O N  M E N U ]";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
                Console.WriteLine(str);

                str = "Enter Year Level : ";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 12);
                Console.Write(str);
                yearLevel = Convert.ToInt32(Console.ReadLine());

                str = "Enter Section Name : ";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 14);
                Console.Write(str);
                sectionName = Console.ReadLine();

                str = "Enter Teacher Name : ";
                Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 16);
                Console.Write(str);
                teacherName = Console.ReadLine();

                AddSectionMenu(yearLevel, sectionName, teacherName, students);
            }
            public static void EditSection()
            {
                Console.Clear();
                Display.DisplayHeader();

                string str = "[ C L A S S  S E C T I O N  M E N U ]";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
                Console.WriteLine(str);

                string currentDirectory = Directory.GetCurrentDirectory() + "/Sections";
                string[] files = Directory.GetFiles(currentDirectory);
                ArrayList sectionNames = new ArrayList();
                int ctr = 1;
                int rowNo = 12;

                str = "Section List";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 10);
                Console.WriteLine(str);

                string rowLine = " +----+----------------------------------+ ";
                string line = "|    |                                  | ";

                Console.SetCursorPosition((Console.WindowWidth - rowLine.Length) / 2, rowNo++);
                Console.WriteLine(rowLine);

                foreach (var file in files)
                {
                    string sectName = file.Remove(0, currentDirectory.Length + 1);
                    sectName = sectName.Remove(sectName.Length - 4);
                    sectionNames.Add(sectName);

                    Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, rowNo);
                    Console.WriteLine(line);

                    Console.SetCursorPosition((Console.WindowWidth / 2) - 19, rowNo);
                    Console.WriteLine(ctr.ToString());

                    Console.SetCursorPosition((Console.WindowWidth / 2) - 13, rowNo);
                    Console.WriteLine(sectName);

                    rowNo++;
                    ctr++;
                    Console.SetCursorPosition((Console.WindowWidth - rowLine.Length) / 2, rowNo++);
                    Console.WriteLine(rowLine);
                }

                str = "Enter a section name to view the section info or back to return to menu";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, rowNo + 4);
                Console.WriteLine(str);

                bool isNotOkay = true;

                do
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 6);
                    Console.Write("Enter your choice : ");
                    string userChoice = Console.ReadLine();

                    if (userChoice == "back")
                    {
                        isNotOkay = false;
                        SectionModule();
                    }
                    else
                    {
                        bool isPresent = false;
                        foreach (string classSectionName in sectionNames)
                        {
                            if (classSectionName == userChoice)
                                isPresent = true;
                        }

                        if (isPresent)
                        {
                            string teacherName;
                            ClassSection cs = ReadSection(userChoice, out teacherName);
                            AddSectionMenu(Convert.ToInt32(userChoice[0].ToString()), userChoice.Substring(1, userChoice.Length-1), teacherName, cs.GetAllStudents());
                            isNotOkay = false;
                        }
                        else
                        {
                            str = "Invalid section name...";
                            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 8);
                            Console.Write(str);
                            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 6);
                            Console.Write("                                          ");
                        }

                    }
                } while (isNotOkay);
            }
            public static void DeleteSection()
            {
                Console.Clear();
                Display.DisplayHeader();

                string str = "[ C L A S S  S E C T I O N  M E N U ]";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
                Console.WriteLine(str);

                string currentDirectory = Directory.GetCurrentDirectory() + "/Sections";
                string[] files = Directory.GetFiles(currentDirectory);
                ArrayList sectionNames = new ArrayList();
                int ctr = 1;
                int rowNo = 12;

                str = "Section List";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 10);
                Console.WriteLine(str);

                string rowLine = " +----+----------------------------------+ ";
                string line = "|    |                                  | ";

                Console.SetCursorPosition((Console.WindowWidth - rowLine.Length) / 2, rowNo++);
                Console.WriteLine(rowLine);

                foreach (var file in files)
                {
                    string sectName = file.Remove(0, currentDirectory.Length + 1);
                    sectName = sectName.Remove(sectName.Length - 4);
                    sectionNames.Add(sectName);

                    Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, rowNo);
                    Console.WriteLine(line);

                    Console.SetCursorPosition((Console.WindowWidth / 2) - 19, rowNo);
                    Console.WriteLine(ctr.ToString());

                    Console.SetCursorPosition((Console.WindowWidth / 2) - 13, rowNo);
                    Console.WriteLine(sectName);

                    rowNo++;
                    ctr++;
                    Console.SetCursorPosition((Console.WindowWidth - rowLine.Length) / 2, rowNo++);
                    Console.WriteLine(rowLine);
                }

                str = "Enter a section name to delete or back to return to menu";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, rowNo + 4);
                Console.WriteLine(str);

               bool isNotOkay = true;

                do
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 6);
                    Console.Write("Enter your choice : ");
                    string userChoice = Console.ReadLine();

                    if (userChoice == "back")
                    {
                        isNotOkay = false;
                        SectionModule();
                    }
                    else
                    {
                        bool isPresent = false;
                        foreach (string classSectionName in sectionNames)
                        {
                            if (classSectionName == userChoice)
                                isPresent = true;
                        }

                        if (isPresent)
                        {
                            File.Delete(currentDirectory + "/" + userChoice + ".sec");
                            DeleteSection();
                            isNotOkay = false;
                        }
                        else
                        {
                            str = "Invalid section name...";
                            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 8);
                            Console.Write(str);
                            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, rowNo + 6);
                            Console.Write("                                          ");
                        }

                    }
                } while (isNotOkay);
            }
            public static ClassSection ReadSection(string sectionName, out string teacherName)
            {
                FileStream input = new FileStream(Directory.GetCurrentDirectory() + "/Sections/" + sectionName + ".sec", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader fin = new StreamReader(input);

                ClassSection cs = new ClassSection();
                string sectionID = fin.ReadLine().Remove(0, 12);
                teacherName = fin.ReadLine().Remove(0, 9);
                int yearLevel = sectionID[0];

                cs.SectionID = sectionID;
                
                fin.ReadLine();
                fin.ReadLine();

                string maleStudent;
                string femaleStudent;
                string lastName;
                string firstName;
                string middleName;
                int age;

                do
                {
                    lastName = "";
                    firstName = "";
                    middleName = "";
                    age = 0;

                    maleStudent = fin.ReadLine();
                    if (maleStudent == "Female: " || maleStudent == "") break;
                    else
                    {
                        int startLoc = 0;
                        int endLoc = 0;
                        for (int i = 0; i < maleStudent.Length; i++)
                        {
                            if (Char.IsLetter(maleStudent[i]))
                            {
                                startLoc = i;
                                break;
                            }
                        }
                        endLoc = maleStudent.IndexOf(',', startLoc);
                        lastName = maleStudent.Substring(startLoc, endLoc - startLoc);

                        startLoc = endLoc + 1;
                        endLoc = maleStudent.IndexOf(',', startLoc);

                        firstName = maleStudent.Substring(startLoc, endLoc - startLoc);

                        startLoc = endLoc + 1;
                        endLoc = maleStudent.IndexOf('\t', startLoc);

                        middleName = maleStudent.Substring(startLoc, endLoc - startLoc);

                        startLoc = endLoc + 1;
                        endLoc = maleStudent.Length;
                        age = Convert.ToInt32(maleStudent.Substring(startLoc, endLoc - startLoc));

                        cs.AddStudent(new Student("", yearLevel, lastName, middleName, firstName, DateTime.Today, 'M'));
                    }
                } while (maleStudent != "Female: " || maleStudent != "");

                fin.ReadLine();
                fin.ReadLine();

                do
                {
                    lastName = "";
                    firstName = "";
                    middleName = "";
                    age = 0;

                    femaleStudent = fin.ReadLine();
                    if (femaleStudent == "") break;
                    else
                    {
                        int startLoc = 0;
                        int endLoc = 0;
                        for (int i = 0; i < femaleStudent.Length; i++)
                        {
                            if (Char.IsLetter(femaleStudent[i]))
                            {
                                startLoc = i;
                                break;
                            }
                        }
                        Console.WriteLine(femaleStudent);
                        endLoc = femaleStudent.IndexOf(',', startLoc);
                        lastName = femaleStudent.Substring(startLoc, endLoc - startLoc);

                        startLoc = endLoc + 1;
                        endLoc = femaleStudent.IndexOf(',', startLoc);

                        firstName = femaleStudent.Substring(startLoc, endLoc - startLoc);

                        startLoc = endLoc + 1;
                        endLoc = femaleStudent.IndexOf('\t', startLoc);

                        middleName = femaleStudent.Substring(startLoc, endLoc - startLoc);

                        startLoc = endLoc + 1;
                        endLoc = femaleStudent.Length;
                        age = Convert.ToInt32(femaleStudent.Substring(startLoc, endLoc - startLoc));

                        Console.WriteLine(firstName.Trim() + " " + middleName.Trim() + " " + lastName.Trim() + " " + age);

                        cs.AddStudent(new Student("", yearLevel, lastName, middleName, firstName, DateTime.Today, 'F'));
                    }
                } while (femaleStudent != "");
                fin.Close();
                return cs;
            }
            public static void AddSectionMenu(int yearLevel, string sectionName, string teacherName, ArrayList students)
            {
                Console.Clear();
                Display.DisplayHeader();
                string str = "[ C L A S S  S E C T I O N  M E N U ]";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
                Console.WriteLine(str);

                ClassSection cs = new ClassSection(yearLevel + sectionName);
                printAllSectionStudents(students);

                str = "Class Section Menu :";
                Console.SetCursorPosition(20, 10);
                Console.WriteLine(str);

                str = "[a]. Add Student";
                Console.SetCursorPosition(20, 12);
                Console.WriteLine(str);

                str = "[b]. Remove Student";
                Console.SetCursorPosition(20, 14);
                Console.WriteLine(str);

                str = "[c]. Save";
                Console.SetCursorPosition(20, 16);
                Console.WriteLine(str);

                str = "[d]. Cancel";
                Console.SetCursorPosition(20, 18);
                Console.WriteLine(str);

                string studentNo;
                Student newStudent = new Student("0", 0, "none", "none", "none", Convert.ToDateTime("1/1/1990"), 'M');

                switch (GetMenuChoice(20, 22))
                {
                    case 'a':

                        str = "Enter student no : ";
                        Console.SetCursorPosition(20, 24);
                        Console.Write(str);
                        studentNo = Console.ReadLine();

                        switch (yearLevel)
                        {
                            case 1:
                                newStudent = firstYearStudents.GetStudentByID(studentNo);
                                break;
                            case 2:
                                newStudent = secondYearStudents.GetStudentByID(studentNo);
                                break;
                            case 3:
                                newStudent = thirdYearStudents.GetStudentByID(studentNo);
                                break;
                            case 4:
                                newStudent = fourthYearStudents.GetStudentByID(studentNo);
                                break;
                        }

                        students.Add(newStudent);
                        break;
                    case 'b':
                        str = "Enter student no : ";
                        Console.SetCursorPosition(20, 24);
                        Console.Write(str);
                        studentNo = Console.ReadLine();

                        foreach (Student student in students)
                        {
                            if (student.StudentNo == studentNo)
                            {
                                newStudent = student;
                                break;
                            }
                        }

                        students.Remove(newStudent);

                        break;
                    case 'c':
                        SaveSection(yearLevel, sectionName, teacherName, students);

                        str = "Section has been successfully saved!!!";
                        Console.SetCursorPosition(20, 28);
                        Console.Write(str);
                        Console.ReadKey();

                        break;
                    case 'd':
                        SectionModule();
                        break;
                }
                AddSectionMenu(yearLevel, sectionName, teacherName, students);
            }
            public static void SaveSection(int yearLevel, string sectionName, string teacherName, ArrayList students)
            {
                string path = Directory.GetCurrentDirectory() + "/Sections/";
                string sectionID = yearLevel.ToString() + sectionName;
                FileStream output = new FileStream(path + sectionID + ".sec", FileMode.OpenOrCreate, FileAccess.Write);

                StreamWriter fout = new StreamWriter(output);
                Student[] studentArray = (Student[])students.ToArray(typeof(Student));

                fout.WriteLine("Section ID: " + sectionID);
                fout.WriteLine("Teacher Name: " + teacherName);
                fout.WriteLine();

                int ctr = 1;
                var maleStudents = (from student in studentArray where student.Gender == 'M' select student).ToArray();

                if (maleStudents.Count() > 0)
                {
                    fout.WriteLine("Male : ");
                    foreach (Student maleStudent in maleStudents)
                    {
                        fout.WriteLine(ctr++ + ". " + maleStudent.LastName + ", " + maleStudent.FirstName + ", " + maleStudent.MiddleName + "\t" + maleStudent.Age);
                    }
                }

                ctr = 1;
                var femaleStudents = (from student in studentArray where student.Gender == 'F' select student).ToArray();

                if (femaleStudents.Count() > 0)
                {
                    fout.WriteLine("\nFemale : ");
                    foreach (Student femaleStudent in femaleStudents)
                    {
                        fout.WriteLine(ctr++ + ". " + femaleStudent.LastName + ", " + femaleStudent.FirstName + ", " + femaleStudent.MiddleName + "\t" + femaleStudent.Age);
                    }
                }

                fout.WriteLine();
                fout.WriteLine("Total Male : " + maleStudents.Count());
                fout.WriteLine("Total Female : " + femaleStudents.Count());
                fout.WriteLine("Total Students : " + studentArray.Count());

                fout.Close();
            }
            public static void printAllSectionStudents(ArrayList students)
            {
                string str = "Students List : ";
                int ctr = 1;
                int rowNo = 10;
                int width50Percent = Console.WindowWidth - Convert.ToInt32(Console.WindowWidth * 0.50);

                Console.SetCursorPosition(width50Percent, rowNo++);
                Console.Write(str);

                foreach (Student student in students)
                {
                    Console.SetCursorPosition(width50Percent, rowNo++);
                    Console.Write(ctr++ + ".  " + student.FirstName + " " + student.LastName);
                }
            }
        #endregion

        public static void DisplayTeacherMenu()
        {
            Console.Clear();
            Display.DisplayHeader();

            string str = "[ T E A C H E R  M E N U ]";
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 5);
            Console.WriteLine(str);
        }
    }
}
