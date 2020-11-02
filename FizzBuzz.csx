void FizzBuzzRange(int van, int tot) {
    for(var i = van; i <= tot; i++) {
        Console.WriteLine(FizzBuzz(i));
   }
}

string FizzBuzz(int i) {
    string output = "";
    if(i % 3 == 0) {
        output = "Fizz";
    }
    if(i % 5 == 0) {    
        return output + "Buzz";
    }
    if(string.IsNullOrWhiteSpace(output)) {
        return i.ToString();
    }
    return output;
}

FizzBuzzRange(1, 100);

void TestFizzBuzz(int number, string output) {
    if(FizzBuzz(number) != output) throw new Exception();
}

TestFizzBuzz(1, "1");
TestFizzBuzz(3, "Fizz");
TestFizzBuzz(5, "Buzz");
TestFizzBuzz(15, "FizzBuzz");
