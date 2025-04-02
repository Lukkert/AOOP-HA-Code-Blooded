using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace VisualizationApp.Models;
public static class StackManipulator
{
    public static Stack<T> RemoveElement<T>(Stack<T> stack, T element)
    {
        Stack<T> tempStack = new Stack<T>();
        
        // Remove the element from the stack
        while (stack.Count > 0)
        {
            T current = stack.Pop();
            if (!current!.Equals(element))
            {
                tempStack.Push(current);
            }
        }

        // Restore the original stack
        while (tempStack.Count > 0)
        {
            stack.Push(tempStack.Pop());
        }

        return stack;
    }
}