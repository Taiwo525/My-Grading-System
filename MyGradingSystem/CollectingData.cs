using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGradingSystem
{
    class CollectingData
    {
        // Globally declaring and initailizing some variables
        string? courseCodes;
        int courseUnits;
        int courseScores;
        string sum = "";
        int totalCourseUnitRegistered = 0;
        int totalCourseUnitPassed = 0;
        int totalWeightPoint = 0;
        int numOfCourses;
        public void Mydata()
        {
            // Coolecting my Datas
            mine:
            Console.Write("Enter the number Of course: ");
            string? numInput = Console.ReadLine();
            while (!int.TryParse(numInput, out numOfCourses) || numOfCourses <= 0)
            {
                Console.WriteLine("Input must be greater than 0");
                goto mine;
            }

            for (int i = 0; i < numOfCourses; i++)
            {
                do
                {
                    Console.Write($"Enter the course code for course {i + 1}: ");
                    courseCodes = Console.ReadLine();
                } while (courseCodes == "");

                jump:
                Console.Write($"Enter the course unit for course {i + 1}: ");
                string? Cunit = Console.ReadLine();
                // Checking to make sure the inputs is a number 
                while (!int.TryParse(Cunit, out courseUnits) || courseUnits < 1 || courseUnits > 5)
                {
                    Console.WriteLine("Course Unit must be between 1 and 5");
                    goto jump;
                }

                here:
                Console.Write($"Enter the course score for course {i + 1}: ");
                string? myScore = Console.ReadLine();
                // Checking to make sure the inputs is a number
                while (!int.TryParse(myScore, out courseScores) || courseScores < 1 || courseScores > 100)
                {
                    Console.WriteLine("Course Score must be between 1 and 100");
                    goto here;
                }
                Console.Clear();

                char grade;
                int gradeUnit;
                int weightPoint;
                string remark;
                // Stateting Conditions for gradings
                if (courseScores >= 70 && courseScores <= 100)
                {
                    grade = 'A';
                    gradeUnit = 5;
                    weightPoint = courseUnits * gradeUnit;
                    remark = "Excellent";
                }
                else if (courseScores >= 60 && courseScores <= 69)
                {
                    grade = 'B';
                    gradeUnit = 4;
                    weightPoint = courseUnits * gradeUnit;
                    remark = "Very Good";
                }
                else if (courseScores >= 50 && courseScores <= 59)
                {
                    grade = 'C';
                    gradeUnit = 3;
                    weightPoint = courseUnits * gradeUnit;
                    remark = "Good";
                }
                else if (courseScores >= 45 && courseScores <= 49)
                {
                    grade = 'D';
                    gradeUnit = 2;
                    weightPoint = courseUnits * gradeUnit;
                    remark = "Fair";
                }
                else if (courseScores >= 40 && courseScores <= 44)
                {
                    grade = 'E';
                    gradeUnit = 1;
                    weightPoint = courseUnits * gradeUnit;
                    remark = "Pass";
                }
                else if (courseScores >= 0 && courseScores <= 39)
                {
                    grade = 'F';
                    gradeUnit = 0;
                    weightPoint = courseUnits * gradeUnit;
                    remark = "Fail";
                }
                else
                {
                    Console.WriteLine("Invalid input entered");
                    break;
                }
                sum = sum + $"| {courseCodes,-15} | {courseUnits,-13} | {grade,-7} | {gradeUnit,-12} | {weightPoint,-12} | {remark,-9} | \n";
                
                totalCourseUnitRegistered += courseUnits;
                if (grade != 'F')
                {
                    totalCourseUnitPassed += courseUnits;
                }
                totalWeightPoint += weightPoint;
            }
            // GPA calculation
            double gpa = totalWeightPoint / totalCourseUnitRegistered;

            //Display table
            Console.WriteLine("|-----------------|---------------|---------|--------------|--------------|-----------| ");
            Console.WriteLine("|  COURSE & CODE  |  COURSE UNIT  |  GRADE  |  GRADE-UNIT  |  WEIGHT Pt.  |  REMARK   | ");
            Console.WriteLine("|-----------------|---------------|---------|--------------|--------------|-----------| ");
            Console.WriteLine($"{sum}");
            Console.WriteLine("|_________________|_______________|_________|______________|______________|___________| \n \n");

            // Data calculation...
            Console.WriteLine($"Total Course Unit Registered is {totalCourseUnitRegistered}");
            Console.WriteLine($"Total Course Unit Passed is {totalCourseUnitPassed}");
            Console.WriteLine($"Total Weight Point is {totalWeightPoint}");
            Console.WriteLine($"Your GPA is = {gpa:F2} to 2 decimal places.");
            Console.ReadKey();
           
        }
    }
}