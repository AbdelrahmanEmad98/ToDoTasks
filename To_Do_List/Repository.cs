using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    public static class Repository
    {
        public static List<TaskToDo> tasks = new List<TaskToDo>();
        public static List<TaskToDo> CompletedTasks = new List<TaskToDo>();

        public static int AddTask (TaskToDo task)
        {
            if (task.Status == Status.NotCompleted)
            {


                if (tasks.Count == 0)
                {
                    tasks.Add(task);
                }
                else
                {
                    if ((tasks.FirstOrDefault(x => x.Name == task.Name)) != null)
                    {
                        return 0;
                    }
                    else
                    {
                        int index = -1;
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (task.Priority < tasks[i].Priority)
                            {
                                index = i;
                                break;
                            }

                        }
                        if (index > 0)
                            tasks.Insert(index, task);
                        else
                            tasks.Add(task);

                    }

                }
            }
            else
            {
                if (CompletedTasks.Count == 0)
                {
                    CompletedTasks.Add(task);
                }
                else
                {
                    if ((CompletedTasks.FirstOrDefault(x => x.Name == task.Name)) != null)
                    {
                        return 0;
                    }
                    else
                    {
                        int index = -1;
                        for (int i = 0; i < CompletedTasks.Count; i++)
                        {
                            if (task.Priority < CompletedTasks[i].Priority)
                            {
                                index = i;
                                break;
                            }

                        }
                        if (index > 0)
                            CompletedTasks.Insert(index, task);
                        else
                            CompletedTasks.Add(task);

                    }

                }
            }
            return 1;
        }
        public static void DisplayAll()
        {
            int i = 0;
            if (tasks.Count == 0 && CompletedTasks.Count == 0)
            {
                Console.WriteLine("Your Not Completed Tasks Is Empty");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Your Completed Tasks Is Empty");
            }else if(tasks.Count == 0 && CompletedTasks.Count != 0)
            {
                i = 0;
                Console.WriteLine("Your List Is Empty");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------");
                foreach (var task in CompletedTasks)
                {
                    Console.WriteLine($"Id : {++i} , {task.ToString()}");
                }
            }else if(tasks.Count != 0 && CompletedTasks.Count == 0)
            {
                i = 0;
                foreach (var task in tasks)
                {
                    Console.WriteLine($"Id : {++i} , {task.ToString()}");
                }
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Your Completed Tasks Is Empty");
            }

            else
            {
                i = 0;
                foreach (var task in tasks)
                {
                    Console.WriteLine($"Id : {++i} , {task.ToString()}");
                }
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------");
                
                foreach (var task in CompletedTasks)
                {
                    Console.WriteLine($"Id : {++i} , {task.ToString()}");
                }
            }

        }
        public static int DeleteTask(int id)
        {
            if (id - 1 < tasks.Count)
            {
                tasks.RemoveAt(id-1);
            }
            else
            {
                CompletedTasks.RemoveAt(id-tasks.Count- 1);

            }
            return 1;

        }

        public static int UpdateTaskName(int id , string name)
        {
            if(id  <= tasks.Count)
            {
                id -= 1;
                tasks[id].Name = name;
            }
            else if(id - tasks.Count <= CompletedTasks.Count && id > tasks.Count)
            {
                //out of range
                id = id-tasks.Count- 1;
                CompletedTasks[id].Name = name;
            }
            else
            {
                return 0;
            }
            return 1;
       
        }

        public static int UpdateTaskPriority(int id, Priority priority)
        {
            
            if (id <= tasks.Count)
            {
                id -= 1;
                TaskToDo updatedTask = new TaskToDo()
                {
                    Name = tasks[id].Name,
                    Priority = priority,
                    Description = tasks[id].Description,
                    Status = tasks[id].Status,

                };
                tasks.RemoveAt(id);
                AddTask(updatedTask);

            }
            else
            {
                id = id - tasks.Count - 1;
                TaskToDo updatedTask = new TaskToDo()
                {
                    Name = CompletedTasks[id].Name,
                    Priority = priority,
                    Description = CompletedTasks[id].Description,
                    Status = CompletedTasks[id].Status,

                };
                CompletedTasks.RemoveAt(id);
                AddTask(updatedTask);
            }
            return 1;
        }

        public static void UpdateStatus(int id)
        {
            if (id <= tasks.Count)
            {
                id -= 1;
                TaskToDo updatedTask = new TaskToDo()
                {
                    Name = tasks[id].Name,
                    Priority = tasks[id].Priority,
                    Description = tasks[id].Description,
                    Status = Status.Completed,

                };
                tasks.RemoveAt(id);
                AddTask(updatedTask);
            }
            else
            {
                id = id - tasks.Count - 1;
                TaskToDo updatedTask = new TaskToDo()
                {
                    Name = CompletedTasks[id].Name,
                    Priority = CompletedTasks[id].Priority,
                    Description = CompletedTasks[id].Description,
                    Status = Status.NotCompleted,

                };
                CompletedTasks.RemoveAt(id);
                AddTask(updatedTask);
            }
        }
    }


}
