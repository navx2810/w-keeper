Tokens and Challenges

A token is an identity of a user sent to the client and examined on the server. Like a badge or ticket.
When the server recieves a request to a controller, the token is parsed and the Identity is challenged.

Think of it like this: When you enter airport security, you hand an security member your passport(**Token**) and they check it to see if your allowed to through(**Challenge**). If everything is okay, you're allowed here.


# Authentication
I need to find a way to:

* Create a token from a given server-side database-pulled user
* Parse a token string into the client-side user
* Check the validity of the token.

# Authorization
I must:

* Create an interface that holds all the challenges a developer can call in the 

# Challenges

I could add the challenges as extension methods to the User class, but that ties me down to the specific instance.
I guess it has to though, it's unique per application.
If there are multiple user types, then this doesn't work.

Unless you abstract your user class to specifically only the (user)name and password. Then let the rest of the info come in seperate tables or interfaces.

I need to be able to keep track of challenge errors so I can post it back to the server.

Request comes in ->
    Tokenizer checks token and parses it.
    Challenger runs tests.
    If any failed, the request is returned with a bad request sending over the error messages from the challenger.
    Otherwise, request was a success. Carry on.


## Consider

Think about making challenges return nothing. When a challenge is called, it will either create an entry into the error list or not. ex:

challenger.IsAdmin();
challenger.CanAccess("/this/directory");

if(challenger.Errors.HasAny())

Maybe I might even turn it into a builder-like, fluent api call.

var isInvalid = challenge.
    .IsAdmin(user)
    .CanAccess(user, "/this/directory")
    .HasErrors;