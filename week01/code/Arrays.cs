using System.Data;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        ////////////////////////////////////////
        /// Process:
        /// 1.  Create an array, the first number should be the starting number and the second number will be the number of times to multiply by
        /// 2.  Create a for loop that will iterate through the length of the array
        /// 3.  Inside the for loop, set each index of the array to be the starting number multiplied by (index + 1)
        /// 4.  Return the array
        ////////////////////////////////////////


        List<double> result = new();
        for (int i = 0; i < length; i++)
        {
            result.Add(number * (i + 1));
        }

        return result.ToArray();
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static int[] RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        ////////////////////////////////////////
        /// Process:
        /// 1.  Create an list, with at least 4 elements
        /// 2.  Create a four loop that will loop 3 times
        /// 3.  Create an element that will count the items in the list
        /// 4.  Inside the four loop, store the last element in the list in a variable, 
        /// 5.  Remove the last element 
        /// 6.  Then insert the stored variable into position 0
        /// 7.  Return the array
        ////////////////////////////////////////

        // List<int> result = new();
        int listCount = data.Count;
        for (int i = 1; i <= amount; i++)
        {
            int lastElement = data[listCount - 1];
            data.RemoveAt(listCount - 1);
            data.Insert(0, lastElement);
        }
        return data.ToArray(); ;

    }
}
