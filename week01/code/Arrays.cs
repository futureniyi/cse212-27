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
        // Step 1: Create a new double array with enough space to hold the requested number of multiples.
        var multiples = new double[length];

        // Step 2: Loop through each position in the array.
        // Step 3: For each position, multiply the starting number by the multiple count.
        // The multiple count is i + 1 because arrays start at index 0, but multiples start at 1.
        for (var i = 0; i < length; i++)
            multiples[i] = number * (i + 1);

        // Step 4: Return the completed array of multiples.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Find the index where the last "amount" values begin.
        // These values are the ones that need to move to the front of the list.
        var splitIndex = data.Count - amount;

        // Step 2: Copy the values from the split index to the end of the list.
        // This is the right-side section that will become the beginning of the rotated list.
        var rightSide = data.GetRange(splitIndex, amount);

        // Step 3: Copy the values from the beginning of the list up to the split index.
        // This is the left-side section that will move after the right-side section.
        var leftSide = data.GetRange(0, splitIndex);

        // Step 4: Clear the original list so it can be rebuilt in the rotated order.
        data.Clear();

        // Step 5: Add the right-side section first, then the left-side section.
        data.AddRange(rightSide);
        data.AddRange(leftSide);
    }
}
