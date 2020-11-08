# CSClassIndexersUsingReflection
At this project I used the standard C# System.Reflection to create class indexers very much alike the standard JS object key and value system.

So, in JS we can create a standard object like this:

const test = {
  property1: 14,
  property2: 45,
  double(x){
    return x*2;
  }
}

At the above case the JS object test has two properties and a function. And with that we can call any one of its properties using their key. For exemple:

test["proprety1"] --> 14 We can access the property value by its name just passing a string that matches the key name on the indexer of the class
test["double"] --> f double(x){return x*2} At this case the return was a function that can be executed like that
test["double"](5) --> 10 The function was returned by the indexer and then executed using the value of 5 to be used on the execution, that returnd the value of 10 as expected

Thinking at the number of possibilities that this simple piece of code can bring, I created  a static class using Reflection that could make any object in C# have
this same property. If you want your class to have this behavior you just have to import the Indexer.js to somewhre at your project repository 
(NOTE: if you're on a differet namespace, you will have to use the using directive to import the class), then just create the indexer using the standard indexers with getter
and setter of C# and the GetPropertyOrMethod and SetProperty methods (as shown on lines 47-64 of the program.cs), the behavior that your class will have with those methods is 
yours to chose and implement, I just abstracted the whole thing.

This code may not be yet so usefull, but I did this project for training my programing skills and testing my abbility to create and develop basic stuff.
I'm happy with the result. Enjoy if you like!
