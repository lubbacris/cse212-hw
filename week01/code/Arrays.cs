public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    // / <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //Problem 1
        
        /* 
        Plan for MULTIPLESOF Function:
        
        Step 1: Understanding the requirements:
        - We need to generate an array containing the 'length' number of elements
        - Each element will be a multiple of the input 'number'
        - The first element should be number * 1, the second number * 2, .
        - Example: MultiplesOf(3, 4) should return [3, 6, 9, 12]
        
        Step 2: Determining the algorithm:
        - We need to create an empty array of doubles with size 'length'
        - Use a for loop to iterate from 0 to length-1
        - For each iteration i, calculate: number * (i + 1)
          - We are going to use i+1 because array indices start at 0, but we want first multiple, not 0
        - Now store the calculated value in array[i]
        - Then return the completed array
        
        Step 3: Considering edge cases:
        - Function handles positive and negative numbers (test cases show negative works)
        - Function handles fractional numbers (test case uses 1.5)
        - Length is guaranteed positive, so no need to check for 0 or negative
        
        Step 4: Implementation outline:
        1. Create result array of size 'length'
        2. Loop i from 0 to length-1
        3. Calculate multiple = number * (i + 1)
        4. Store multiple in result[i]
        5. Return result array
        */
        
        // Implementation following the above plan:
        
        // Step 1: Creating an array to hold the results
        double[] resultArray = new double[length];
        
        // Step 2: Using a for loop to calculate each multiple
        for (int index = 0; index < length; index++)
        {
            // Step 3: Calculate the (index+1)th multiple of the number
            // For index = 0: number * 1 (first multiple)
            // For index = 1: number * 2 (second multiple)
            // For index = 2: number * 3 (third multiple), etc.
            double currentMultiple = number * (index + 1);
            
            // Step 4: Storing the calculated multiple in the array
            resultArray[index] = currentMultiple;
        }
        
        // Step 5: Return the completed array containing all multiples
        return resultArray;
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
        
        // Problem 2
        
        /*
        Plan for ROTATELISTRIGHT Function:
        
        Step 1: Understanding the requirements:
        - We need to rotate a list to the RIGHT by a specified amount
        - Example: List [1,2,3,4,5,6,7,8,9] with amount=3 becomes [7,8,9,1,2,3,4,5,6]
        - We should modify the original list in place, not create a new list
        - Amount will be between 1 and data.Count inclusive
        
        Step 2: Visualizing the rotation:
        - For right rotation by 'amount', the last 'amount' elements will move to the front
        - The remaining elements will then shift to the right
        
        Step 3: Considering different solution approaches:
        Approach A: Using List methods (GetRange, RemoveRange, InsertRange)
          1. Getting the last 'amount' elements
          2. Removing them from the end of the list
          3. Inserting them at the beginning
          
        Approach B: Using modular arithmetic and a temporary list
          1. Creating a new list of same size
          2. For each position i in new list, calculate original position: (i + data.Count - amount) % data.Count
          3. Copy element from original position to new list position
          4. Copy new list back to original list
          
        Approach C: Using multiple rotations
        
        Step 4: We are choosing Approach A (using List methods) for clarity and efficiency:
        - This approach directly manipulates the list using built-in methods
        - It's intuitive, take end part, remove it, put it at front
        - Handles edge cases very well
        
        Step 5: Handle edge cases:
        - If list is empty, nothing to do
        - If amount == data.Count, rotation brings us back to original (no change)
        - We'll handle these to avoid unnecessary operations
        
        Step 6: Implementation outline for Approach A:
        1. Check for empty list or amount == 0 - return immediately
        2. Normalize amount: amount % data.Count (handles amount > data.Count defensively)
        3. If normalized amount == 0, return (no change needed)
        4. Get the last 'amount' elements using GetRange(startIndex, count)
        5. Remove these elements from the end using RemoveRange(startIndex, count)
        6. Insert the saved elements at the beginning using InsertRange(index, collection)
        */
        
        // Implementation following the above plan:
        
        // Step 1: Checking for trivial cases where no rotation is needed
        if (data == null || data.Count == 0 || amount == 0)
        {
            return; // Nothing to rotate
        }
        
        // Step 2: Normalizing the amount to handle cases where amount might be >= data.Count
        // The modulo operation ensures amount is within 0 to data.Count-1
        // Example: If data.Count = 9 and amount = 12, then effectiveAmount = 12 % 9 = 3
        int effectiveAmount = amount % data.Count;
        
        // Step 3: If effectiveAmount is 0 after normalization, list will be unchanged
        // This happens when amount is a multiple of data.Count
        if (effectiveAmount == 0)
        {
            return; // Full rotation brings us back to original
        }
        
        // Step 4: Calculating the starting index of the elements to move to the front
        // For right rotation, we want the last 'effectiveAmount' elements
        // If list has 9 elements and effectiveAmount = 3, startIndex = 9 - 3 = 6
        int startIndex = data.Count - effectiveAmount;
        
        // Step 5: Extract the elements that need to move to the front
        // GetRange creates a new List<int> containing the specified range
        List<int> elementsToMove = data.GetRange(startIndex, effectiveAmount);
        
        // Step 6: Remove those elements from their original position at the end
        // This modifies the original list by removing 'effectiveAmount' elements starting at startIndex
        data.RemoveRange(startIndex, effectiveAmount);
        
        // Step 7: Insert the extracted elements at the beginning of the list
        // InsertRange modifies the original list by inserting the collection at position 0
        data.InsertRange(0, elementsToMove);
        
        // The list is now successfully rotated right by 'amount'
        
    }
}