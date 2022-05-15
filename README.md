# Project

You are required to design and implement a software system that manages and organizes all transactions and operations related to social media network like Facebook and twitter. This system will be a platform for users to perform operations like posting content and sending messages. On the other hand, the system administrator can do many administrative functions like suspending users and registering new user accounts.
The system maintains a database for all involved users accounts, messages, posts, and reports. This information is accessed by users (administrator and client users) to achieve their desired functionalities and be updated continuously throughout the running time of the system. Every user account has the following information: username (unique), password, status, first name, last name, location, and age. Regarding the message, it has the following information: sender’s username, receiver’s username, text, subject, and priority (this field has 2 values: high, or low). For every post, the system records the following information: username (unique), content, and category. Lastly, every report has only username of the reported account. Every system user (client user or administrator) must log in using his username and password. As a prerequisite, your implementation program must initially load the database with a set of user accounts and posts at the beginning. The following data must be loaded automatically as is upon running your program:

### USER ACCOUNTS

| Username | Password |  Status   | First Name | Last Name | Location | Age |   Friends   |
| :------: | :------: | :-------: | :--------: | :-------: | :------: | :-: | :---------: |
|   UN1    |    11    |  Active   |    Zaid    |   Ahmad   |  Irbid   | 28  |   UN2,UN3   |
|   UN2    |    22    |  Active   |    Omar    |  Farook   |  Irbid   | 30  | UN1,UN3,UN5 |
|   UN3    |    33    |  Active   |    Maha    |   Hani    |  Amman   | 42  | UN2,UN4,UN6 |
|   UN4    |    44    |  Active   |   Hamzah   |    Ali    |  Zarqa   | 37  |   UN5,UN6   |
|   UN5    |    55    |  Active   |   Salma    |  Waleed   |  Jerash  | 40  | UN1,UN3,UN4 |
|   UN6    |    66    | Suspended |    Ali     |  Khaled   |  Amman   | 26  |   UN1,UN2   |

### POSTS

| Username |                    Content                     | Category |
| :------: | :--------------------------------------------: | :------: |
|   UN1    |         Liverpool beats Man. City 2-1          |  Sport   |
|   UN1    | Apple expects to release iPhone 14 in October  |   News   |
|   UN2    |            Expect snow next Sunday             | Weather  |
|   UN3    |    Italy fails to qualify for the World Cup    |  Sport   |
|   UN3    |     The deficit exceeds 2 million dollars      | Economy  |
|   UN5    | The minimum wage has been raised to 300 dinars | Economy  |

The system has only one administrator that logs in using the following credential:

- username: admin
- password: 0

---

Every user account has 2 status values: active or suspended. A user account is suspended when at least 2 active users send reports to administrator complaining that user. The administrator can re-activate the user account later. The suspended user accounts cannot log into the system.
A user can send a message to any user account registered in the system (not only his friends) and tag it with either high or low priority. The priority tag is used to make high-priority message appears on the top of receiver’s message inbox. In case a user receives many high-priority messages, then they must be shown on the top of low-priority messages with any order for both.
The system is required to satisfy the main functional requirements for all users (client user and administrator). This necessitate to explore high-level use cases then decomposing them into sub use cases to draw a full image of the involved implementation steps. Consequently, our system has the following high-level use cases:

### ADMINISTRATOR FUNCTIONS:

1. Register new user account.
2. View all user accounts.
3. Suspend user account.
4. Activate user account.
5. Post new content.

### USER FUNCTIONS:

6. Send a message.
7. View all my posts.
8. View all received messages.
9. View my last-updated wall.
10. Filter my wall.
11. Send report to administrator.

YOUR PROGRAM MUST SHOW ONLY THE FUNCTIONS RELATED TO THE CURRENTLY LOGGED-IN USER. THEREFORE, UPON RUNNING YOUR PROGRAM, THE SYSTEM MUST DISPLAY TWO LOGIN OPTIONS (LOGIN SCREEN): AS 1ADMINISTRATOR, OR AS 2USER. THEN BASED ON THE SELECTED USER TYPE, THE SYSTEM MUST DISPLAY THE OPTIONS RELATED TO THE LOGGED-IN USER.
THE OPTIONS MENU FOR BOTH USER AND ADMINISTRATOR MUST PROVIDE LOGOUT OPTION TO RETURN TO THE LOGIN SCREEN SO AS TO ENABLE HIM TO LOG IN WITH DIFFERENT USER TYPE.

---

## Detailes

In details, below are the involved steps for each use case:

### Use case 1: Register new user account.

- Firstly, the system asks administrator to enter the following information related to the new user account: username, password, status, first name, last name, location, age, and list of friends (only usernames are entered).
- Then, a new user account is added to the database.

### Use case 2: View all user accounts.

- The system displays full information (8 fields) of all user accounts (with all status values) in the database. The order of the fields is as in the table above (USER ACCOUNTS).

### Use case 3: Suspend user account.

- Firstly, the system displays all reports in the database.
- Then, the system displays usernames of all user accounts that have been reported by at least 2 active user accounts (the user accounts with at least 2 reports).
- The system asks administrator to enter the username of the user account to be suspended.
- The system changes the status of the selected user account to ‘suspended’ and updates the database accordingly.
- The system removes reports of the selected user account from database.

### Use case 4: Activate user account.

- The system displays usernames of all suspended user accounts (status=’suspended’).
- The system asks administrator to enter the username of the user account to be activated.
- The system changes the status of the selected user account to ‘active’ and updates the database accordingly.

### Use case 5: Post new content.

- The system asks user to enter the content for the new post and the category of the post.
- The system saves the new post in the database (the username is the one for the currently logged-in user account).

### Use case 6: Send a message.

- Firstly, the system displays all usernames for all active user accounts in the system (not only friends).
- The system asks user to enter the receiver’s username.
- The system asks the user to enter a subject for the message, priority (high or low), and the text of the message.
- The system saves the newly created message (the sender’s username is the one of the currently logged-in user account) in the database.

### Use case 7: View all my posts.

- The system displays all posts related to the currently logged-in user account in the following format:
  Example:

```
          Content             | Category
Liverpool beats Man. City 2 1 | Sport
```

### Use case 8: View all received messages

- The system displays full information of all messages that sent to the currently logged-in user account (the receiver’s username is the currently logged-in user account) with high-priority messages shown on the top. The messages must be displayed in the following format:
  Example:

```
Priority | Sender’s first name | Sender’s last name | Subject |            Text
High     | Zaid                | Ahmad              | Meeting | I will meet you next Sunday
```

### Use case 9: View my last-updated wall

- The system displays all posts from all friends of the currently logged-in user account in the following format:
  Example:

```
Friend’s first name | Friend’s last name |           Content             | Category
Zaid                | Ahmad              | Liverpool beats Man. City 2 1 | Sport
```

### Use case 10: Filter my wall

- The system displays all posts from all friends of the currently logged-in user account in the same format as in use case 9.
- The system asks user to enter the category of the desired posts.
- The system displays all posts from all friends based on the entered category in the same format as in use case 9.

### Use case 11: Send report to administrator

- Firstly, the system displays all usernames for all active user accounts in the system (not only friends).
- The system asks user to enter the username for the user account that he wants to report.
- The system adds a new report to the database.

You are required to satisfy implement every step above, else your grade will be affected accordingly. Please don’t assume anything even if it makes sense. In case you do not understand something, please feel free to ask about it.
