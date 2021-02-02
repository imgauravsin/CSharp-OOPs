### Exercise 1 : File operations
```
Get all the files from a given directory and perform the following actions
1.	Return the number of text files in the directory (*.txt).
2.	Return the number of files per extension type.
3.	Return the top 5 largest files, along with their file size (use anonymous types).
4.	Return the file with maximum length.
```


#### Exercise 2 : Exceptions
```
You like teaching mathematics and you are creating a small game for school kids. Game has multiple steps:
1.	Display following message to user: “Enter any number from 1-5"
2.	User enters an option from 1-5, show the exact message to user for the number selected
1)	Enter even number
2)	Enter odd number
3)	Enter a prime number
4)	Enter a negative number
5)	Enter zero
for e.g. if user has selected 1, then show “Enter even number”,
If user does not enter correct number from 1-5 show error message. and then -> GOTO step 1
3.If user has entered correct number, then show success, else show error. -> after this GOTO step 1

To validate type of user input, there should be a validation method, 
which will return true if user input is correct, else validation method will 
throw different exception for different failure scenario.
Create a CustomException class.
Also, when user has played this game for 5 times, show a message to user 
you have played this game for 5 times. Handle this also using exception.
```
