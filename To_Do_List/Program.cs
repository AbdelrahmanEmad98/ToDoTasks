using To_Do_List;

internal class Program
{
    public static void WelcomeMassage()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("\tWelcom To YourList App");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("----------------------------------------");
    }

    public static void Option()
    {
        Console.WriteLine("");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Please Choose Your Option => ");
        Console.WriteLine("1- To Display Your Tasks");
        Console.WriteLine("2- To Add New Task");
        Console.WriteLine("3- To Delete Task");
        Console.WriteLine("4- To Edit Task Name");
        Console.WriteLine("5- To Edit Task Priority");
        Console.WriteLine("6- To Edit Task Status");
        Console.WriteLine("7- To Add New Tasks");
        Console.WriteLine("8- To Edit Name For Many Tasks");
        Console.WriteLine("9- To Exit");
    }

    public static TaskToDo CreateTask()
    {
        string option="e";
        string name, decrp;
        Priority priority;
        Console.WriteLine("Please Enter Task Name & Remember Not Duplicate");
        name = Console.ReadLine();

        Console.WriteLine("Please Enter Task Description");
        decrp = Console.ReadLine();

       Console.WriteLine("Please Choose Task Poriority");
            Console.WriteLine("1- High");
            Console.WriteLine("2- Medium");
            Console.WriteLine("3- Low");
            Console.WriteLine("e- Exit");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    priority = Priority.High;
                    break;
                case "2":
                    priority = Priority.Medium;
                    break;
                case "3":
                    priority = Priority.Low;
                    break;
                default:
                    priority = Priority.NotAssign;
                    break;
            }

        if(priority == Priority.NotAssign || name == string.Empty || name == null) 
        {
            return null;
        }

        return new TaskToDo(name, decrp, priority,Status.NotCompleted);

    }

    
    private static void Main(string[] args)
    {
        WelcomeMassage();
        int option ;
        bool check = false;

        List<TaskToDo> myNewtasks = new List<TaskToDo>();

        

        do
        {
            Option();

             check = int.TryParse(Console.ReadLine(),out option);
            if (check)
            {
                switch (option)
                {
                    case 1:
                        #region Dispaly All Tasks 
                        
                        Console.Clear();
                        WelcomeMassage(); 
                        Console.WriteLine();
                        Repository.DisplayAll();
                        break;
                    #endregion
                    case 2:
                        #region Add New Task


                        Console.Clear();
                        WelcomeMassage();
                        Console.WriteLine();
                        TaskToDo myTask= CreateTask();
                        if (myTask == null)
                        {
                            Console.WriteLine("Task Not Created Successfully");
                        }
                        else
                        {

                            Console.WriteLine(Repository.AddTask(myTask) == 1 ? "Added Successfully":"Added Faild");
                        }

                        break;
                    #endregion
                    case 3:
                        #region Delete Task

                        
                        Console.Clear();
                        WelcomeMassage();
                        Console.WriteLine();
                        if(Repository.tasks.Count == 0) 
                        {
                            Console.WriteLine("No Tasks To Delete");
                        }
                        else
                        {
                            int id ; 
                            bool tr = false ;
                            Console.WriteLine("Please Enter Number of Task To Delete It");
                            Repository.DisplayAll();
                            tr = int.TryParse(Console.ReadLine(), out id);
                            if (tr && id <= Repository.tasks.Count + 1) 
                            {
                                Console.WriteLine(Repository.DeleteTask(id) == 1 ? "Deletes successfully" : "Deleted Failed");
                            }
                            else { Console.WriteLine("Deleted Failed"); }

                            
                        }
                        break;
                    #endregion
                    case 4:
                        #region Edit Task Name

                        
                        int opt2;
                        Console.Clear();
                        WelcomeMassage();
                        Console.WriteLine();
                        Repository.DisplayAll();
                        Console.WriteLine();
                        Console.WriteLine("Please Enter Number of Task To Change it's Name");
                        check = int.TryParse (Console.ReadLine(), out opt2);
                        Console.WriteLine("Please Enter New Name");
                        string newName = Console.ReadLine();
                        if (check && opt2<=(Repository.tasks.Count+Repository.CompletedTasks.Count)+1 && (newName != string.Empty || newName != null ) )
                        {
                            //Repository.UpdateTaskName(opt2, newName);
                            Console.WriteLine(Repository.UpdateTaskName(opt2, newName)==1 ? "Changed <3":"Task Id Not Valid");
                        }
                        else
                        {
                            Console.WriteLine("Invaled Option");
                        }
                        break;
                   #endregion
                    case 5:
                        #region Edit Priority

                        
                        int opt3;
                        string opt4;
                        Priority newPriority;
                        bool check2;
                        Console.Clear();
                        WelcomeMassage();
                        Console.WriteLine();
                        Repository.DisplayAll();
                        Console.WriteLine();
                        Console.WriteLine("Please Enter Number of Task To Change it's Priorty");
                        check = int.TryParse(Console.ReadLine(), out opt3);
                        Console.WriteLine("Please Choose Task Poriority");
                        Console.WriteLine("1- High");
                        Console.WriteLine("2- Medium");
                        Console.WriteLine("3- Low");
                        Console.WriteLine("e- Exit");
                        opt4 = Console.ReadLine() ;
                        switch (opt4)
                        {
                            case "1":
                                newPriority = Priority.High;
                                break;
                            case "2":
                                newPriority = Priority.Medium;
                                break;
                            case "3":
                                newPriority = Priority.Low;
                                break;
                            default:
                                newPriority = Priority.NotAssign;
                                break;
                        }


                        if (check &&  opt3 <= (Repository.tasks.Count + Repository.CompletedTasks.Count) && newPriority != Priority.NotAssign)
                        {
                            Repository.UpdateTaskPriority(opt3, newPriority);
                            Console.WriteLine("Changed <3");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Option");
                        }
                        break;
                    #endregion
                    case 6:
                        #region Edit Status

                        
                        int opt5;
                        Console.Clear();
                        WelcomeMassage();
                        Console.WriteLine();
                        Repository.DisplayAll();
                        Console.WriteLine();
                        Console.WriteLine("Please Enter Number of Task To Change it's Status");
                        check = int.TryParse(Console.ReadLine(), out opt5);
                        if(opt5 <= Repository.tasks.Count+ Repository.CompletedTasks.Count)
                        {
                            Repository.UpdateStatus(opt5);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Option");
                        }
                        break;
                    #endregion
                    case 7:
                        #region Add Many

                        
                        Console.Clear();
                        WelcomeMassage();
                        Console.WriteLine();
                        int i = 0;
                        string flag = string.Empty;
                       
                        TaskToDo myNew = new TaskToDo();
                        do
                        {

                            myNew = CreateTask();
                            if (myNew == null)
                            {
                                Console.WriteLine("Task Not Created Successfully");
                            }
                            else
                            {

                                Console.WriteLine(Repository.AddTask(myNew) == 1 ? "Added Successfully" : "Added Faild");
                            }


                            Console.WriteLine("To add new Task press y OR Y");
                            flag = Console.ReadLine();
                        } while (flag == "Y" || flag == "y");


                        break;
                    #endregion
                    case 8:
                        #region Edit Name For Many Tasks
                        string ids = string.Empty;
                        string[] ids2; 
                        Console.Clear();
                        WelcomeMassage();
                        Console.WriteLine();
                        Repository.DisplayAll();
                        Console.WriteLine();
                        Console.WriteLine("Please Enter Numbers of Tasks To Change Name ");
                        Console.WriteLine("ex : 1&2&...&N ");
                        ids= Console.ReadLine();
                        ids2 =  ids.Split("&");
                        int[] ids3 = new int[ids2.Length];

                        for(i =  0; i < ids2.Length; i++)
                        {
                            int.TryParse(ids2[i], out ids3[i]);
                        }
                        Console.WriteLine("Please Enter New Names");
                        Console.WriteLine("ex:name1&name2&...&nameN");
                        string newNames = Console.ReadLine();
                        string[] newNames2 = newNames.Split("&");
                        int failcount = 0,sucessCount = 0;
                        if(newNames2.Length == ids3.Length)
                        {
                            for(i=0; i < newNames2.Length;i++)
                            {
                                if (ids3[i]<= Repository.CompletedTasks.Count + Repository.tasks.Count)
                                {
                                    Repository.UpdateTaskName(ids3[i], newNames2[i]);
                                    sucessCount++;

                                }
                                else
                                {
                                    failcount++;
                                }

                            }
                            Console.WriteLine($"\n{sucessCount} Changed \n{failcount} Failed");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Options");
                        }
                        #endregion
                        break; 
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Option Please Try Again");
            }

          

        } while (option != 9);
       
    }
}