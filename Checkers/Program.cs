using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Console.WriteLine("To move, select the position of the piece you want to move. To do this, enter in the coordinates of the position. The   coordinates should be row and then column, or y and then x. Then enter the coordinates of the piece you want to move.   Again, row and then column. Your input should be startY StartX EndY EndX. ");
            board.Print();
            while (true)
            {
                string input = Console.ReadLine();

                string[] parts = input.Split(' ');
                
                

                try
                {

                    int row1 = int.Parse(parts[0]);
                    int row2 = int.Parse(parts[1]);
                    int column1 = int.Parse(parts[2]);
                    int column2 = int.Parse(parts[3]);
                    
                    board.Move(row1, row2, column1, column2);
                }
               catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
 
                }
                board.Print();

            }
            
         
        }
    }
}
