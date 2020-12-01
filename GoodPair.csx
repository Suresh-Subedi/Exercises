public class Solution {
    public int NumIdenticalPairs(int[] nums) {
        var numCounts = new Dictionary<int, int>();
        foreach(var num in nums) {
            if(numCounts.ContainsKey(num)) {
                numCounts[num] = numCounts[num] + 1;
            } else {
                numCounts.Add(num, 1);
            }
        }
        
        var goodPairs = 0;
        foreach(var numCount in numCounts) {
            goodPairs += numCount.Value * (numCount.Value - 1)/2;
        }
        return goodPairs;
    }    
}

void TestNumIdenticalPairs(int[] input, int output) {
    var result = new Solution().NumIdenticalPairs(input);
    if(result != output) {
        throw new Exception($"expected output: {output}, actual output: {result}");
    }
}
TestNumIdenticalPairs(new int[]{1,2,3,1,1,3}, 4);
TestNumIdenticalPairs(new int[]{1, 1, 1, 1}, 6);
TestNumIdenticalPairs(new int[]{1, 2, 3}, 0);

Console.WriteLine(new Solution().NumIdenticalPairs(new int[]{1,2,3,1,1,3}));
Console.WriteLine(new Solution().NumIdenticalPairs(new int[]{1, 1, 1, 1}));
Console.WriteLine(new Solution().NumIdenticalPairs(new int[]{1, 2, 3}));
