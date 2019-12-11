This is where the business logic lays
The application states through interfaces what it needs to function, it needs a repository therefore we will have an interface
that defines what methods and variables that repository will use. We will need user authentication,
so we make an interfaces that defines the methods called to the user authentication service with their
input/output. Why? So we can code without them, we will implement them later but we dont care how they work
while we make the business logic.

We will be using CQRS (Command Query Responsibility Segregation ), in one short sentence, we have queries (fetch me this, get me that)
and we have commands (set this in the db, delete the other thing etc).
And mediatR (everyone is dependent on mediatr, mediatr has all dependencies we need, so we can call them at any time anywhere)

Look in Users/Commands/CreateUser, this is commented properly, the rest of commands and queries are not because its just repetitive code. Its all the same 