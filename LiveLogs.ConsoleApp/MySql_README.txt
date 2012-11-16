To Use in a MySql Query Monitoring Context:
===========================================

See Stack Overflow Post: http://stackoverflow.com/questions/568564/how-can-i-view-live-mysql-queries/9398566#9398566

1. Edit the file located at:

C:\Program Files (x86)\MySQL\MySQL Server 5.5\my.ini

Add "add log=development.log" to the bottom of the file, with a comment. (Note saving this file required me to run my text editor as an admin).

Use MySql workbench to open a command line, enter the password.

Run the following to turn on general logging which will record all queries ran:

"SET GLOBAL general_log = 'ON';"

("SET GLOBAL general_log = 'OFF';" to turn off).

This will produce a text file at the following location.

C:\ProgramData\MySQL\MySQL Server 5.5\data\development.log