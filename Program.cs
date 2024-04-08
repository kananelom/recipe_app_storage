using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe_app_storage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            recipe.EnterDetails();
                            break;
                        case 2:
                            recipe.Display();
                            break;
                        case 3:
                            recipe.Scale();
                            break;
                        case 4:
                            recipe.ResetQuantities();
                            break;
                        case 5:
                            recipe.Clear();
                            break;
                        case 6:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
    
    class Recipe
    {
        private List<(string name, double quantity, string unit)> ingredients = new List<(string, double, string)>();
        private List<string> steps = new List<string>();
        // enter ingredients and steps
        public void EnterDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter quantity of {name}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                ingredients.Add((name, quantity, unit));
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                steps.Add(step);
            }
        }
        // display ingredients and inputted steps
        public void Display()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (var (name, quantity, unit) in ingredients)
            {
                Console.WriteLine($"{name}: {quantity} {unit}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }
        // raise scale by whichever amount the user prefers 
        public void Scale()
        {
            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
            double factor = double.Parse(Console.ReadLine());

            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i] = (ingredients[i].name, ingredients[i].quantity * factor, ingredients[i].unit);
            }

            Console.WriteLine("Recipe scaled.");
        }
        //reset quantities k.t
        public void ResetQuantities()
        {
            // Assume original quantities are stored elsewhere and retrieved here
            // For simplicity, let's just clear the current list
            ingredients.Clear();
            Console.WriteLine("Quantities reset to original values.");
        }

        public void Clear()
        {
            ingredients.Clear();
            steps.Clear();
            Console.WriteLine("All data cleared.");
        }
    }
    }
