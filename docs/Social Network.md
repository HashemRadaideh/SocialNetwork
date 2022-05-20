# Social Network

The implementation is separated into multiple files:

- Account.cs

- Acctions.cs

- DataStruct.cs

- Database.cs

- Program.cs

---



## Program.cs

To begin with the Program.cs file is the entry point of the entire program, meaning it's the file that contains the main method, which basically means displaying the welcome message, the menu, and input handling, pretty basic stuff.

### There are few other methods within the Program class that you should know about,

UserLoop() 

self explanatory name, what it does is move the flow of the program toward the user, you may at first consider this redundant and unnecessary, because you can put all the code within the main method, which is true, but it will be harder over all to understand and work with, that's why they are separated.

AdminLoop() 

same as the one above. 

GetLogin()

Enters the user data, username and password, it's a repetitive task so using this method makes it simpler.

parameters none

returns username as a string and password as a string

Added feature is hiding of password.

---

 

## Database.cs

Then moving on to the Database.cs file, it might look intimidating at first glance but it's actually pretty simple, when you open the file you'll see two classes:

- Database

- Table

### Class Database

Modelled after the relational database.

Design pattern singleton, you don't really need to understand this part but what a singleton basically is a class that can only have one instance (object), which means there can't be more than one database through out the program

### Class Table

As for this class it's quite complicated not going to lie, but it's still understandable... hopefully.

In a relational database a table is used to store data, it will have columns signifying the type, and rows which will be the actual data.

In my implementation, the table stores the data in a Hashtable as the value, and we all know that we need a primary key to tell the rows apart, that's why I am using the key value as the primary key, this needs to be reworked I think, I am happy to hear some feedback on my method of doing this.

The data in here is of type object, this way table can be more generic and extended to hold more than one type at a time.

The key of type int, and it's auto generated, needless to say there's no need to provide one when creating a user.

Also a table needs a name so that we can distinguish tables in a database, that's why there is a field called name of type string.

---

 

## Account.cs

File Account.cs this one is the heart and soul of our project, simply put our grades depend on this one.

### Contains three classes overall:

- Account

- User

- Administrator

#### Class Account

The base class for which both User and Administrator extend (inherit from).

##### Contain fields:

- Username: string

- Password: string

- First name: string

- Last name: string

- Age: int

- Status: boolean

- Friends: List<object>    <-- will be explained later

##### Provides:

Overloaded (override) ToString() method, which is used to print the User info.

### Class User

Not implemented yet.

### Class Administrator

Not implemented yet.

---

 

## Acctions

Group of classes used to store information for the system.

### Contains:

- Post

- Message

- Report

These classes are only used to store data, and have some basic functionality.

#### Class Post

used to store information about user posts, these information are:

- Author (owner): int 

- Username: string

- Content: string

#### Class Message

used to store information between the sender and the receiver.

- Sender (id): int

- Receiver (id): int

- Username1: string

- Username2: string

- Content: string

#### Class Report

store information about report, that is used by the admin to suspend an account.

- Reporter (id): int

- Reported (id): int

- Content (id): int

---



## DataStruct.cs

To be fair this one does sound scare, it is nightmare fuel for some people, let alone considering to do it in c#, it was hell on earth for me to implement,  appreciate my work and be happy.

Contains a single class List<T> (generic linked list), which is used through out the program to store the data, for instance database tables storing, and many more.

### Class List<T>

when I said it only implements a single class that was a lie, sort of...

on the outside when you look at it, it does just List<T>, but under the hood there is 3 classes in total.

- Class Node

- Class LinkedList

- Class List<T>

Both class Node and LinkedList are nested within class List<T>, meaning private classes while List<T> is public, and yes classes could be private and public there is also internal, anyways so those classes are nested unaccusable outside of class List<T>, resulting in a single class.

Now you may have noticed this (<T>) symbol, and have been wondering about it since the start, will simply put, it's a generic type, similar to C++ template.

```cpp
template<typename T>
struct Node {
  T data;
  Node* next;  
};
```

this means that when you create an object of type Node you need to provide it with a type.

```cpp
Node<int> x;
```

Note: the type could be anything not just int.

this same thing can be achieved in C#.

```csharp
class Node<T>
{
    T data;
    Node next;
}

Node<int> x;
```

the two codes are equivalent, and that's as far as generic means.

for us we really need it to hold data of type object, so you may say it's quite unnecessary, while it's true, I've done it either way just because I can.

The remaining part of the List<T> class to understand beside how a linked list work, is IEnumerator<T> and IEnumrable interfaces, which implore you to implement.

- public T Current (property)

- object IEnumerator.Current (property)

- public bool MoveNext()

- public void Reset()

- public IEnumerator<T> GetEnumrator()

- IEnumrator IEnumrable.GetEnumrator()

- public void Dispose()

the boring details of how to implement them aren't necessary, all you need to know about them is that they are used to provide foreach loop syntax. 

```csharp
List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
foreach (var element in list)
{
    Console.WriteLine(element);
}
```

instead of writing it like this:

```csharp
List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
for (int i = 0; i < list.Size; i++)
{
    Console.WriteLine(list[i]);
}
```

Note: you can use square brackets to index or even add elements to the list achieved by overloading [] operator read the code if you want to understand more.



---



# Notes:

I use the keyword var to create objects, it's pretty simple instead of providing the type for the reference, you just use the keyword var and c# will understand and provide the type by it self.

As will as nullable operator and some other operators for null checking and forgiving.



---



# Conclusion

C# is horrible 😒

no but for real, I have new found respect for c#, the language is simple because it uses c syntax in have the same features as c++, plus the added feature of running in a virtual environment just like java... it have nothing speacial going on for it that's why I hate it.

Thank you for reading this summary, made with ❤ by Hashem Al-Radaideh.
